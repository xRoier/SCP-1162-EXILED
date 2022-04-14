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
            try
            {
                if(!ev.IsAllowed) return;
                if (Vector3.Distance(ev.Player.Position, Exiled.API.Extensions.RoleExtensions.GetRandomSpawnProperties(RoleType.Scp173).Item1) <= 8.2f)
                {
                    if (plugin.Config.UseHints)
                        ev.Player.ShowHint(plugin.Config.ItemDropMessage, plugin.Config.ItemDropMessageDuration);
                    else
                        ev.Player.Broadcast(plugin.Config.ItemDropMessageDuration, plugin.Config.ItemDropMessage, Broadcast.BroadcastFlags.Normal, true);
                    ev.IsAllowed = false;
                    var oldItem = ev.Item.Base.ItemTypeId;
                    ev.Player.RemoveItem(ev.Item);
                    var newItemType = plugin.Config.Chances[Random.Range(0, plugin.Config.Chances.Count)];
                    var eventArgs = new UsingScp1162EventArgs(ev.Player, newItemType, oldItem);
                    Scp1162Event.OnUsingScp1162(eventArgs);
                    var newItem = Item.Create(eventArgs.ItemAfter);
                    ev.Player.AddItem(newItem);
                    ev.Player.DropItem(newItem);
                }
            }
            catch
            {
                //Ignore, ev.Player.RemoveItem false positive.
            }
        }
    }
}