using Exiled.API.Features.Items;
using Exiled.Events.EventArgs;
using SCP1162.API;
using UnityEngine;

namespace SCP1162
{
    public class EventHandlers
    {
        private Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnItemDropped(DroppingItemEventArgs ev)
        {
            if (ev.Item != null && Vector3.Distance(ev.Player.Position, Exiled.API.Extensions.RoleExtensions.GetRandomSpawnProperties(RoleType.Scp173).Item1) <= 8.2f)
            {
                if (plugin.Config.UseHints)
                    ev.Player.ShowHint(plugin.Config.ItemDropMessage, plugin.Config.ItemDropMessageDuration);
                else
                    ev.Player.Broadcast(plugin.Config.ItemDropMessageDuration, plugin.Config.ItemDropMessage, Broadcast.BroadcastFlags.Normal, true);
                var oldItem = ev.Item.Base.ItemTypeId;
                var newItem = plugin.Config.Chances[Random.Range(0, plugin.Config.Chances.Count)];
                var eventArgs = new UsingScp1162EventArgs(ev.Player, newItem, oldItem);
                Scp1162Event.OnUsingScp1162(eventArgs);
                ev.Item = new Item(eventArgs.ItemAfter);
            }
        }
    }
}