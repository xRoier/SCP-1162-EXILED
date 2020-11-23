using System;
using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace SCP1162_EXI_2._0
{
    public class Config : IConfig
    {
        internal List<ItemType> ChancesItem = new List<ItemType>();
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Use Hints instead of Broadcast?")]
        public bool UseHints { get; set; } = true;
        [Description("Change the message that displays when you drop an item through SCP-1162.")]
        public string ItemDropMessage { get; set; } = "<i>You try to drop the item through <color=yellow>SCP-1162</color> to get another...</i>";
        public ushort ItemDropMessageDuration { get; set; } = 5;
        [Description("The list of items. To add another item, use: ItemName: (LastItemNumber + 1). Ex = GunMP7: 30")]
        public List<string> Chances { get; set; } = new List<string>
        {
            "KeycardO5",
            "SCP500",
            "MicroHID",
            "KeycardNTFCommander",
            "KeycardContainmentEngineer",
            "SCP268",
            "GunCOM15",
            "GrenadeFrag",
            "SCP207",
            "Adrenaline",
            "GunUSP",
            "KeycardFacilityManager",
            "Medkit",
            "KeycardNTFLieutenant",
            "KeycardSeniorGuard",
            "Disarmer",
            "KeycardZoneManager",
            "KeycardScientistMajor",
            "KeycardGuard",
            "Radio",
            "Ammo556",
            "Ammo762",
            "Ammo9mm",
            "GrenadeFlash",
            "WeaponManagerTablet",
            "KeycardScientist",
            "KeycardJanitor",
            "Coin",
            "Flashlight"
        };
        internal void ParseChances()
        {
            ChancesItem.Clear();
            foreach (string chance in Chances)
            {
                ItemType item;
                try
                {
                    item = (ItemType)Enum.Parse(typeof(ItemType), chance, true);
                }
                catch (Exception)
                {
                    Log.Error($"Unable to parse item chance: {chance}.");
                    continue;
                }
                ChancesItem.Add(item);
            }
        }
    }
}
