using Exiled.Events.EventArgs;
using UnityEngine;

namespace SCP1162
{
    public class EventHandlers
    {
        private Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnItemDropped(DroppingItemEventArgs ev)
        {
            if (Vector3.Distance(ev.Player.Position, Exiled.API.Extensions.RoleExtensions.GetRandomSpawnProperties(RoleType.Scp173).Item1) <= 8.2f)
            {
                if(ev.Item == null) return;
                if (plugin.Config.UseHints)
                    ev.Player.ShowHint(plugin.Config.ItemDropMessage, plugin.Config.ItemDropMessageDuration);
                else
                    ev.Player.Broadcast(plugin.Config.ItemDropMessageDuration, plugin.Config.ItemDropMessage, Broadcast.BroadcastFlags.Normal, true);
                if (!plugin.Config.CanSpawnCorpses)
                {
                    ev.IsAllowed = false;
                    ev.Player.RemoveItem(ev.Item);
                    var item = ev.Player.AddItem(plugin.Config.Chances[Random.Range(0, plugin.Config.Chances.Count)]);
                    ev.Player.DropItem(item);
                    return;
                }

                if (Random.Range(0, 14) <= 13)
                {
                    ev.IsAllowed = false;
                    ev.Player.RemoveItem(ev.Item);
                    var item = ev.Player.AddItem(plugin.Config.Chances[Random.Range(0, plugin.Config.Chances.Count)]);
                    ev.Player.DropItem(item);
                }
                else
                {
                    ev.IsAllowed = false;
                    ev.Player.RemoveItem(ev.Item);
                    int roleid = Random.Range(0, 12);
                    switch (roleid)
                    {
                        case 2:
                            roleid = 16;
                            break;
                        case 7:
                            roleid = 17;
                            break;
                        case 14:
                            roleid = 11;
                            break;
                    }
                    Exiled.API.Features.Ragdoll.Spawn((RoleType)roleid, DamageTypes.Falldown, "Corpse", ev.Player.Position + Vector3.up * 5f);
                }
            }
        }
    }
}