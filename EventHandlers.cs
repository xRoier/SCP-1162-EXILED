using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;

namespace SCP1162_EXI_2._0 {
  public class EventHandlers {
    private Plugin plugin;
    public Config Config;
    public EventHandlers(Plugin plugin) { this.plugin = plugin; Config = plugin.Config; }

    internal void OnItemDropped(ItemDroppedEventArgs ev) {
      if (Vector3.Distance(ev.Player.Position, Map.GetRandomSpawnPoint(RoleType.Scp173)) <= 8.2f) {
        if (Config.UseHints) {
          ev.Player.ShowHint(Config.itemdropmessage, Config.itemdropmessageduration);
        }
        else {
          ev.Player.ClearBroadcasts();
          ev.Player.Broadcast(Config.itemdropmessageduration, Config.itemdropmessage);
        }
        int r = Random.Range(0, 14);
        if (r <= 13) {
          ev.Pickup.itemId = Config.ChancesItem.ElementAt(Random.Range(0, Config.ChancesItem.Count)).Value;
        }
        else {
          ev.Pickup.itemId = ItemType.None;
          int roleid = Random.Range(0, 12);
          if (roleid == 2) {
            roleid = 16;
          }
          if (roleid == 7) {
            roleid = 17;
          }
          if (roleid == 14) {
            roleid = 11;
          }
          Timing.RunCoroutine(SpawnCorpse(ev.Player, roleid));
        }
      }
    }
	  
    private IEnumerator < float > SpawnCorpse(Player player, int role) {
      player.GameObject.GetComponent < RagdollManager > ().SpawnRagdoll(player.Position + Vector3.up * 5f, Quaternion.identity, Vector3.zero, role, new PlayerStats.HitInfo(1000f, player.UserId, DamageTypes.Falldown, player.Id), false, "Corpse", "Corpse", 0);
      yield return Timing.WaitForSeconds(0.15f);
      yield break;
    }
  }
}
