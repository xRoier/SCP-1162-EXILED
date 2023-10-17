using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Enums;
using PlayerRoles;
using SCP1162.API;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Exiled.API.Features.Doors;

namespace SCP1162
{
    public class EventHandlers
    {
        private readonly Plugin _plugin;
        public EventHandlers(Plugin plugin) => _plugin = plugin;
        public const float RadiusSqr = 8f * 8f;
        private Dictionary<Player, int> playerUseCount = new Dictionary<Player, int>();
        private Dictionary<Player, int> playerHurtCount = new Dictionary<Player, int>();
        private Dictionary<Player, int> playerExponentialHurtChance = new Dictionary<Player, int>();

        private void IncreaseHurtChance(Player player)
        {
            if (!playerExponentialHurtChance.ContainsKey(player))
            {
                playerExponentialHurtChance[player] = 0;
            }

            int increaseAmount = UnityEngine.Random.Range(_plugin.Config.ExponentialHurtChanceMin, _plugin.Config.ExponentialHurtChanceMax + 1);
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
            if (_plugin.Config.SCP1162Hurts)
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

            bool isIn1162Zone = _plugin.Config.UseNew173Spawn
                                ? Vector3.Distance(ev.Player.Position, RoleTypeId.Scp173.GetRandomSpawnLocation().Position) <= 8.2f
                                : IsPlayerIn1162Zone(ev.Player);

            if (!isIn1162Zone) return;

            if (_plugin.Config.SCP1162Hurts)
            {
                if (!playerHurtCount.ContainsKey(ev.Player))
                {
                    playerHurtCount[ev.Player] = 0;
                    Log.Debug($"Player {ev.Player.Nickname} entered SCP-1162 zone. Initializing hurt counters.");
                }

                if (!playerUseCount.TryGetValue(ev.Player, out int uses)) playerUseCount[ev.Player] = 0;

                int chanceOfBeingHurt = _plugin.Config.ExponentialHurtChance
                                            ? playerExponentialHurtChance.ContainsKey(ev.Player)
                                                ? playerExponentialHurtChance[ev.Player]
                                                : 0
                                            : Math.Min(uses * _plugin.Config.HurtChance, 100);

                if (_plugin.Config.ExponentialHurtChance)
                {
                    IncreaseHurtChance(ev.Player);
                }
                else
                {
                    Log.Debug($"Player {ev.Player.Nickname} has a {chanceOfBeingHurt}% chance of being hurt. [Static]");
                }

                if (UnityEngine.Random.Range(0, 100) < chanceOfBeingHurt)
                {
                    playerHurtCount[ev.Player]++;
                    playerUseCount[ev.Player]++;

                    EffectType selectedEffect;
                    if (_plugin.Config.HurtEffectChances.Count > 2)
                    {
                        var randomIndex = UnityEngine.Random.Range(0, _plugin.Config.HurtEffectChances.Count);
                        selectedEffect = _plugin.Config.HurtEffectChances.Keys.ElementAt(randomIndex);
                    }
                    else selectedEffect = _plugin.Config.HurtEffectChances.Keys.First();

                    Log.Debug($"Player {ev.Player.Nickname} will be hurt with effect {selectedEffect}.");

                    if (playerHurtCount[ev.Player] < _plugin.Config.HurtLimit)
                    {
                        ev.Player.Hurt(_plugin.Config.HurtAmount);
                        ev.Player.EnableEffect(selectedEffect, _plugin.Config.HurtEffectChances[selectedEffect]);

                        if (_plugin.Config.UseHints) ev.Player.ShowHint(_plugin.Config.HurtMessage, _plugin.Config.MessageDuration);
                        else ev.Player.Broadcast(_plugin.Config.MessageDuration, _plugin.Config.HurtMessage, Broadcast.BroadcastFlags.Normal, true);

                        if (_plugin.Config.ExponentialHurtChance)
                        {
                            playerUseCount[ev.Player] = 0;
                            playerExponentialHurtChance[ev.Player] = 0;
                        }
                        return;
                    }
                    else
                    {
                        ev.Player.Kill("SCP-1162");
                        if (_plugin.Config.ExponentialHurtChance)
                        {
                            playerUseCount[ev.Player] = 0;
                            playerExponentialHurtChance[ev.Player] = 0;
                        }
                        Log.Debug($"Player {ev.Player.Nickname} exceeded hurt limit and was killed.");
                        return;
                    }
                }
            }


            if (_plugin.Config.UseHints) ev.Player.ShowHint(_plugin.Config.ItemDropMessage, _plugin.Config.MessageDuration);
            else ev.Player.Broadcast(_plugin.Config.MessageDuration, _plugin.Config.ItemDropMessage, Broadcast.BroadcastFlags.Normal, true);

            ev.IsAllowed = false;
            var oldItem = ev.Item.Base.ItemTypeId;
            ev.Player.RemoveItem(ev.Item);
            var newItemType = _plugin.Config.ItemChancesList[UnityEngine.Random.Range(0, _plugin.Config.ItemChancesList.Count)];
            var eventArgs = new UsingScp1162EventArgs(ev.Player, newItemType, oldItem);
            Scp1162Event.OnUsingScp1162(eventArgs);
            var newItem = Item.Create(eventArgs.ItemAfter);
            ev.Player.AddItem(newItem);
            ev.Player.DropItem(newItem);

            Log.Debug($"Player {ev.Player.Nickname} used SCP-1162. Dropped {oldItem} and received {newItemType}.");
        }
    }
}