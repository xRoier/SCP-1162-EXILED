using System.Collections.Generic;
using EXILED;
using EXILED.Extensions;
using UnityEngine;
using MEC;

namespace SCP1162
{
	public class EventHandlers
	{
		public Plugin Plugin;

		public EventHandlers(Plugin plugin) => Plugin = plugin;
		public void OnItemDrop(ItemDroppedEvent ev)
		{
				Vector3 randomSP = Map.GetRandomSpawnPoint(RoleType.Scp173);
				int range1162 = 8;
				float num = randomSP.x + range1162;
				float num2 = randomSP.y + range1162;
				float num3 = randomSP.z + range1162;
				float num4 = randomSP.x - range1162;
				float num5 = randomSP.y - range1162;
				float num6 = randomSP.z - range1162;
					if (ev.Player.GetPosition().x <= num && ev.Player.GetPosition().x >= num4 && ev.Player.GetPosition().y <= num2 && ev.Player.GetPosition().y >= num5 && ev.Player.GetPosition().z <= num3 && ev.Player.GetPosition().z >= num6)
					{
						ev.Player.ClearBroadcasts();
						ev.Player.Broadcast(5, Plugin.msg1162, true);
						int num7 = new System.Random().Next(1, 86);
						if (num7 >= 1 && num7 <= 4)
						{
							ev.Item.ItemId = ItemType.Coin;
						}
						if (num7 >= 5 && num7 <= 8)
						{
							ev.Item.ItemId = ItemType.Disarmer;
						}
						if (num7 >= 9 && num7 <= 12)
						{
							ev.Item.ItemId = ItemType.GrenadeFlash;
						}
						if (num7 >= 13 && num7 <= 16)
						{
							ev.Item.ItemId = ItemType.Flashlight;
						}
						if (num7 >= 17 && num7 <= 20)
						{
							ev.Item.ItemId = ItemType.Medkit;
						}
						if (num7 >= 21 && num7 <= 24)
						{
							ev.Item.ItemId = ItemType.Radio;
						}
						if (num7 >= 25 && num7 <= 27)
						{
							ev.Item.ItemId = ItemType.KeycardJanitor;
						}
						if (num7 >= 28 && num7 <= 30)
						{
							ev.Item.ItemId = ItemType.KeycardScientist;
						}
						if (num7 >= 31 && num7 <= 33)
						{
							ev.Item.ItemId = ItemType.KeycardSeniorGuard;
						}
						if (num7 >= 34 && num7 <= 36)
						{
							ev.Item.ItemId = ItemType.KeycardZoneManager;
						}
						if (num7 >= 37 && num7 <= 39)
						{
							ev.Item.ItemId = ItemType.KeycardScientistMajor;
						}
						if (num7 >= 40 && num7 <= 42)
						{
							ev.Item.ItemId = ItemType.KeycardGuard;
						}
						if (num7 >= 43 && num7 <= 44)
						{
							ev.Item.ItemId = ItemType.GunCOM15;
						}
						if (num7 >= 45 && num7 <= 46)
						{
							ev.Item.ItemId = ItemType.GunUSP;
						}
						if (num7 >= 47 && num7 <= 48)
						{
							ev.Item.ItemId = ItemType.KeycardNTFLieutenant;
						}
						if (num7 >= 49 && num7 <= 50)
						{
							ev.Item.ItemId = ItemType.GrenadeFrag;
						}
						if (num7 == 51)
						{
							ev.Item.ItemId = ItemType.MicroHID;
						}
						if (num7 == 52)
						{
							ev.Item.ItemId = ItemType.KeycardFacilityManager;
						}
						if (num7 >= 53 && num7 <= 56)
						{
							ev.Item.ItemId = ItemType.Ammo556;
						}
						if (num7 >= 57 && num7 <= 60)
						{
							ev.Item.ItemId = ItemType.Ammo762;
						}
						if (num7 >= 61 && num7 <= 64)
						{
							ev.Item.ItemId = ItemType.Ammo9mm;
						}
						if (num7 == 65)
						{
							ev.Item.ItemId = ItemType.KeycardNTFCommander;
						}
						if (num7 >= 66 && num7 <= 69)
						{
							ev.Item.ItemId = ItemType.WeaponManagerTablet;
						}
						if (num7 >= 70 && num7 <= 72)
						{
							ev.Item.ItemId = ItemType.KeycardContainmentEngineer;
						}
						if (num7 == 73)
						{
							ev.Item.Delete();
							int num8 = new System.Random().Next(0, 12);
							if (num8 == 2)
							{
								num8 = 16;
							}
							if (num8 == 7)
							{
								num8 = 17;
							}
							if (num8 == 11)
							{
								num8 = 15;
							}
						Timing.RunCoroutine(SpawnBodies(ev.Player, num8, 1));
						}
						if (num7 == 74)
						{
							ev.Item.ItemId = ItemType.SCP500;
						}
						if (num7 >= 75 && num7 <= 78)
						{
							ev.Item.ItemId = ItemType.SCP207;
						}
						if (num7 >= 79 && num7 <= 82)
						{
							ev.Item.ItemId = ItemType.Adrenaline;
						}
						if (num7 >= 83 && num7 <= 85)
						{
							ev.Item.ItemId = ItemType.SCP268;
						}
						if (num7 == 86)
						{
							ev.Item.ItemId = ItemType.KeycardO5;
						}
					}
		}


		/* AdminTools EventHandlers.cs #Line 847 */
		private IEnumerator<float> SpawnBodies(ReferenceHub player, int role, int count)
		{
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				player.gameObject.GetComponent<RagdollManager>().SpawnRagdoll(player.gameObject.transform.position + Vector3.up * 5f, Quaternion.identity, role, new PlayerStats.HitInfo(1000f, player.characterClassManager.UserId, DamageTypes.Falldown, player.queryProcessor.PlayerId), false, "SCP-343", "SCP-343", 0);
				yield return Timing.WaitForSeconds(0.15f);
				num = i;
			}
			yield break;
		}
	}
}
