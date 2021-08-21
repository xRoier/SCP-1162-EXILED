using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP1162
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Use Hints instead of Broadcast?")]
        public bool UseHints { get; set; } = true;
        [Description("Can SCP-1162 spawn corpses?")]
        public bool CanSpawnCorpses { get; set; } = true;
        [Description("Change the message that displays when you drop an item through SCP-1162.")]
        public string ItemDropMessage { get; set; } = "<i>You try to drop the item through <color=yellow>SCP-1162</color> to get another...</i>";
        public ushort ItemDropMessageDuration { get; set; } = 5;
        [Description("The list of items.")]
        public List<Exiled.API.Enums.ItemType> Chances { get; set; } = new List<Exiled.API.Enums.ItemType>
        {
            Exiled.API.Enums.ItemType.KeycardO5,
            Exiled.API.Enums.ItemType.Scp500,
            Exiled.API.Enums.ItemType.MicroHid,
            Exiled.API.Enums.ItemType.KeycardNtfCommander,
            Exiled.API.Enums.ItemType.KeycardContainmentEngineer,
            Exiled.API.Enums.ItemType.Scp268,
            Exiled.API.Enums.ItemType.GunCom15,
            Exiled.API.Enums.ItemType.Scp207,
            Exiled.API.Enums.ItemType.Adrenaline,
            Exiled.API.Enums.ItemType.GunCom18,
            Exiled.API.Enums.ItemType.KeycardFacilityManager,
            Exiled.API.Enums.ItemType.Medkit,
            Exiled.API.Enums.ItemType.KeycardNtfLieutenant,
            Exiled.API.Enums.ItemType.KeycardGuard,
            Exiled.API.Enums.ItemType.GrenadeHe,
            Exiled.API.Enums.ItemType.KeycardZoneManager,
            Exiled.API.Enums.ItemType.KeycardGuard,
            Exiled.API.Enums.ItemType.Radio,
            Exiled.API.Enums.ItemType.Ammo9X19,
            Exiled.API.Enums.ItemType.Ammo12Gauge,
            Exiled.API.Enums.ItemType.Ammo44Cal,
            Exiled.API.Enums.ItemType.Ammo556X45,
            Exiled.API.Enums.ItemType.Ammo762X39,
            Exiled.API.Enums.ItemType.GrenadeFlash,
            Exiled.API.Enums.ItemType.KeycardScientist,
            Exiled.API.Enums.ItemType.KeycardJanitor,
            Exiled.API.Enums.ItemType.Coin,
            Exiled.API.Enums.ItemType.Flashlight
        };
    }
}
