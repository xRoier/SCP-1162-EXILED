using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Enums;
using SCP1162.API;
using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Extensions;
using Exiled.API.Features.Doors;
using PlayerRoles;
using UnityEngine;

namespace SCP1162;

public class EventHandlers
{
    private const float RadiusSqr = 8f * 8f;
    private readonly Dictionary<Player, int> playerUseCount = new();
    private readonly Dictionary<Player, int> playerHurtCount = new();
    private readonly Dictionary<Player, int> playerExponentialHurtChance = new();

    private void IncreaseHurtChance(Player player)
    {
        if (!playerExponentialHurtChance.ContainsKey(player)) playerExponentialHurtChance[player] = 0;
        
        int increaseAmount = UnityEngine.Random.Range(SCP1162.Instance.Config.ExponentialHurtChanceMin, SCP1162.Instance.Config.ExponentialHurtChanceMax + 1);
        playerExponentialHurtChance[player] += increaseAmount;
        playerExponentialHurtChance[player] = Mathf.Min(playerExponentialHurtChance[player], 100);
        Log.Debug($"Player {player.Nickname} has a {playerExponentialHurtChance[player]}% chance of being hurt. [Increasing by {increaseAmount}]");
    }

    public bool IsPlayerIn1162Zone(Player player)
    {
        Door scp173Door = Door.List.FirstOrDefault(door => door.Name == "173_GATE");

        if (scp173Door == null)
        {
            Log.Warn("Failed to find SCP-173's door.");
            return false;
        }

        Vector3 insideChamberReference = scp173Door.Position + scp173Door.Transform.rotation * new Vector3(-1f, 0f, -8f);

        float distanceSqr = (player.Position - insideChamberReference).sqrMagnitude;
        return distanceSqr <= RadiusSqr;
    }

    public void OnPlayerDied(DiedEventArgs ev)
    {
        if (SCP1162.Instance.Config.SCP1162Hurts)
        {
            if (playerUseCount.ContainsKey(ev.Player))
            {
                playerUseCount[ev.Player] = 0;
                Log.Debug($"Player {ev.Player.Nickname} died. Resetting use count.");
            }
        }
    }

    public void OnItemDropped(DroppingItemEventArgs ev)
    {
        if (!ev.IsAllowed) return;
        bool isIn1162Zone = SCP1162.Instance.Config.UseNew173Spawn ? Vector3.Distance(ev.Player.Position, RoleTypeId.Scp173.GetRandomSpawnLocation().Position) <= 8.2f : IsPlayerIn1162Zone(ev.Player);
        
        if (!isIn1162Zone) return;

        if (SCP1162.Instance.Config.SCP1162Hurts)
        {
            if (!playerHurtCount.ContainsKey(ev.Player))
            {
                playerHurtCount[ev.Player] = 0;
                Log.Debug($"Player {ev.Player.Nickname} entered SCP-1162 zone. Initializing hurt counters.");
            }

            if (!playerUseCount.TryGetValue(ev.Player, out int uses)) playerUseCount[ev.Player] = 0;

            int chanceOfBeingHurt = SCP1162.Instance.Config.ExponentialHurtChance ? playerExponentialHurtChance.TryGetValue(ev.Player, out var value) ? value : 0 : Math.Min(uses * SCP1162.Instance.Config.HurtChance, 100);

            if (SCP1162.Instance.Config.ExponentialHurtChance) IncreaseHurtChance(ev.Player);
            else Log.Debug($"Player {ev.Player.Nickname} has a {chanceOfBeingHurt}% chance of being hurt. [Static]");
            
            if (UnityEngine.Random.Range(0, 100) < chanceOfBeingHurt)
            {
                playerHurtCount[ev.Player]++;
                playerUseCount[ev.Player]++;

                EffectType selectedEffect;
                if (SCP1162.Instance.Config.HurtEffectChances.Count > 2)
                {
                    var randomIndex = UnityEngine.Random.Range(0, SCP1162.Instance.Config.HurtEffectChances.Count);
                    selectedEffect = SCP1162.Instance.Config.HurtEffectChances.Keys.ElementAt(randomIndex);
                }
                else selectedEffect = SCP1162.Instance.Config.HurtEffectChances.Keys.First();

                Log.Debug($"Player {ev.Player.Nickname} will be hurt with effect {selectedEffect}.");

                if (playerHurtCount[ev.Player] < SCP1162.Instance.Config.HurtLimit)
                {
                    ev.Player.Hurt(SCP1162.Instance.Config.HurtAmount);
                    ev.Player.EnableEffect(selectedEffect, SCP1162.Instance.Config.HurtEffectChances[selectedEffect]);

                    if (SCP1162.Instance.Config.UseHints) ev.Player.ShowHint(SCP1162.Instance.Config.HurtMessage, SCP1162.Instance.Config.MessageDuration);
                    else ev.Player.Broadcast(SCP1162.Instance.Config.MessageDuration, SCP1162.Instance.Config.HurtMessage, Broadcast.BroadcastFlags.Normal, true);

                    if (!SCP1162.Instance.Config.ExponentialHurtChance) return;
                    playerUseCount[ev.Player] = 0;
                    playerExponentialHurtChance[ev.Player] = 0;
                    return;
                }

                ev.Player.Kill("SCP-1162");
                if (SCP1162.Instance.Config.ExponentialHurtChance)
                {
                    playerUseCount[ev.Player] = 0;
                    playerExponentialHurtChance[ev.Player] = 0;
                }
                Log.Debug($"Player {ev.Player.Nickname} exceeded hurt limit and was killed.");
                return;
            }
        }


        if (SCP1162.Instance.Config.UseHints) ev.Player.ShowHint(SCP1162.Instance.Config.ItemDropMessage, SCP1162.Instance.Config.MessageDuration);
        else ev.Player.Broadcast(SCP1162.Instance.Config.MessageDuration, SCP1162.Instance.Config.ItemDropMessage, Broadcast.BroadcastFlags.Normal, true);

        ev.IsAllowed = false;
        var oldItem = ev.Item.Base.ItemTypeId;
        ev.Player.RemoveItem(ev.Item);
        var newItemType = SCP1162.Instance.Config.ItemChancesList[UnityEngine.Random.Range(0, SCP1162.Instance.Config.ItemChancesList.Count)];
        
        var eventArgs = new UsingScp1162EventArgs(ev.Player, newItemType, oldItem);
        Scp1162Event.OnUsingScp1162(eventArgs);
        var newItem = Item.Create(eventArgs.ItemAfter);
        
        ev.Player.AddItem(newItem);
        ev.Player.DropItem(newItem);

        Log.Debug($"Player {ev.Player.Nickname} used SCP-1162. Dropped {oldItem} and received {newItemType}.");
    }
}