using System;
using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace SCP1162_EXI_2._0
{
    public class Config : IConfig
    {
        internal Dictionary<float, ItemType> ChancesItem = new Dictionary<float, ItemType>();
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Use Hints instead of Broadcast?")]
        public bool UseHints { get; set; } = true;
        [Description("Change the message that displays when you drop an item through SCP-1162.")]
        public string itemdropmessage { get; set; } = "<i>You try to drop the item through <color=yellow>SCP-1162</color> to get another...</i>";
        public ushort itemdropmessageduration { get; set; } = 5;
        [Description("The list of items. To add another item, use: ItemName: (LastItemNumber + 1). Ex = GunMP7: 30")]
        public Dictionary<string, float> Chances { get; set; } = new Dictionary<string, float>
        {
            {
                "KeycardO5", 1
            },
            {
                "SCP500", 2
            },
            {
                "MicroHID", 3
            },
            {
                "KeycardNTFCommander", 4
            },
            {
                "KeycardContainmentEngineer", 5
            },
            {
                "SCP268", 6
            },
            {
                "GunCOM15", 7
            },
            {
                "GrenadeFrag", 8
            },
            {
                "SCP207", 9
            },
            {
                "Adrenaline", 10
            },
            {
                "GunUSP", 11
            },
            {
                "KeycardFacilityManager", 12
            },
            {
                "Medkit", 13
            },
            {
                "KeycardNTFLieutenant", 14
            },
            {
                "KeycardSeniorGuard", 15
            },
            {
                "Disarmer", 16
            },
            {
                "KeycardZoneManager", 17
            },
            {
                "KeycardScientistMajor", 18
            },
            {
                "KeycardGuard", 19
            },
            {
                "Radio", 20
            },
            {
                "Ammo556", 21
            },
            {
                "Ammo762", 22
            },
            {
                "Ammo9mm", 23
            },
            {
                "GrenadeFlash", 24
            },
            {
                "WeaponManagerTablet", 25
            },
            {
                "KeycardScientist", 26
            },
            {
                "KeycardJanitor", 27
            },
            {
                "Coin", 28
            },
            {
                "Flashlight", 29
            }
        };
        internal void ParseChances()
        {
            ChancesItem.Clear();
            foreach (KeyValuePair<string, float> chance in Chances)
            {
                ItemType item;
                try
                {
                    item = (ItemType)Enum.Parse(typeof(ItemType), chance.Key, true);
                }
                catch (Exception)
                {
                    Log.Error($"Unable to parse item chance: {chance.Key}.");
                    continue;
                }
                ChancesItem.Add(chance.Value, item);
            }
        }
    }
}
