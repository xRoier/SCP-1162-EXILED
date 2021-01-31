using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace SCP1162_EXI_2._0
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
        public List<ItemType> Chances { get; set; } = new List<ItemType>
        {
            ItemType.KeycardO5,
            ItemType.SCP500,
            ItemType.MicroHID,
            ItemType.KeycardNTFCommander,
            ItemType.KeycardContainmentEngineer,
            ItemType.SCP268,
            ItemType.GunCOM15,
            ItemType.GrenadeFrag,
            ItemType.SCP207,
            ItemType.Adrenaline,
            ItemType.GunUSP,
            ItemType.KeycardFacilityManager,
            ItemType.Medkit,
            ItemType.KeycardNTFLieutenant,
            ItemType.KeycardSeniorGuard,
            ItemType.Disarmer,
            ItemType.KeycardZoneManager,
            ItemType.KeycardScientistMajor,
            ItemType.KeycardGuard,
            ItemType.Radio,
            ItemType.Ammo556,
            ItemType.Ammo762,
            ItemType.Ammo9mm,
            ItemType.GrenadeFlash,
            ItemType.WeaponManagerTablet,
            ItemType.KeycardScientist,
            ItemType.KeycardJanitor,
            ItemType.Coin,
            ItemType.Flashlight
        };
    }
}
