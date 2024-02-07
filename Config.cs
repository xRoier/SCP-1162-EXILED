using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;

namespace SCP1162;

public class Config : IConfig
{
    [Description("Plugin Settings")]
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;

    [Description("If Disabled, it will use private broadcasts instead of hints.")]
    public bool UseHints { get; set; } = true;

    [Description("If Enabled, it will use SCP-173's New containment chamber located in HCZ, instead of LCZ's 173 Containment Chamber.")]
    public bool UseNew173Spawn { get; set; }

    [Description("Determines if SCP-1162 has a chance to punish players for extended use.")]
    public bool SCP1162Hurts { get; set; }
    public int HurtLimit { get; set; } = 5;
    public int HurtChance { get; set; } = 50;
    public ushort HurtAmount { get; set; } = 60;
    public bool HurtEffects { get; set; } = false;
    public Dictionary<EffectType, ushort> HurtEffectChances { get; set; } = new()
    {
        {EffectType.Blinded, 5},
        {EffectType.Stained, 5},
    };

    [Description("Determines if the chances of getting hurt increase exponentially with each use of SCP-1162.")]
    public bool ExponentialHurtChance { get; set; } = false;
    public ushort ExponentialHurtChanceMin { get; set; } = 5;
    public ushort ExponentialHurtChanceMax { get; set; } = 10;

    [Description("SCP-1162 Messages.")]
    public string HurtMessage { get; set; } = "<b><size=20><color=red>[SCP-1162]</color> You feel a sharp excruciating pain trying to use SCP-1162.</size></b>";
    public string ItemDropMessage { get; set; } = "<b><size=20><color=green>[SCP-1162]</color> You try to drop the item to get another.</size></b>";
    public ushort MessageDuration { get; set; } = 5;

    [Description("The list of item chances.")]
    public List<ItemType> ItemChancesList { get; set; } = new()
    {
        ItemType.KeycardO5,
        ItemType.SCP500,
        ItemType.MicroHID,
        ItemType.KeycardMTFCaptain,
        ItemType.KeycardContainmentEngineer,
        ItemType.SCP268,
        ItemType.GunCOM15,
        ItemType.SCP207,
        ItemType.Adrenaline,
        ItemType.GunCOM18,
        ItemType.KeycardFacilityManager,
        ItemType.Medkit,
        ItemType.KeycardMTFOperative,
        ItemType.KeycardMTFPrivate,
        ItemType.KeycardGuard,
        ItemType.GrenadeHE,
        ItemType.KeycardZoneManager,
        ItemType.KeycardGuard,
        ItemType.Radio,
        ItemType.Ammo9x19,
        ItemType.Ammo12gauge,
        ItemType.Ammo44cal,
        ItemType.Ammo556x45,
        ItemType.Ammo762x39,
        ItemType.GrenadeFlash,
        ItemType.KeycardScientist,
        ItemType.KeycardJanitor,
        ItemType.Coin,
        ItemType.Flashlight
    };
}