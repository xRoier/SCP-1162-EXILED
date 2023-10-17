[![Github All Releases](https://img.shields.io/github/downloads/xRoier/SCP-1162-EXILED/total?color=blueviolet&style=for-the-badge)]()
# SCP-1162-EXILED

Turn 173 spawn into SCP-1162.
If you drop an item inside the "cage"/room of Scp-173 you will get another one.

# Config
```
SCP-1162:
  # Plugin Settings
  is_enabled: true
  debug: true
  # If Disabled, it will use private broadcasts instead of hints.
  use_hints: true
  # If Enabled, it will use SCP-173's New containment chamber located in HCZ, instead of LCZ's 173 Containment Chamber.
  use_new173_spawn: false
  # Determines if SCP-1162 has a chance to punish players for extended use.
  s_c_p1162_hurts: true
  hurt_limit: 5
  hurt_chance: 50
  hurt_amount: 60
  hurt_effects: false
  hurt_effect_chances:
    Blinded: 5
    AmnesiaVision: 5
  # Determines if the chances of getting hurt increase exponentially with each use of SCP-1162.
  exponential_hurt_chance: true
  exponential_hurt_chance_min: 5
  exponential_hurt_chance_max: 10
  # SCP-1162 Messages.
  hurt_message: '<b><size=24><color=red>[SCP-1162]</color> You feel a sharp excruciating pain trying to use SCP-1162.</size></b>'
  item_drop_message: '<b><size=24><color=green>[SCP-1162]</color> You try to drop the item to get another.</size></b>'
  message_duration: 5
  # The list of item chances.
  item_chances_list:
  - KeycardO5
  - SCP500
  - MicroHID
  - KeycardMTFCaptain
  - KeycardContainmentEngineer
  - SCP268
  - GunCOM15
  - SCP207
  - Adrenaline
  - GunCOM18
  - KeycardFacilityManager
  - Medkit
  - KeycardMTFOperative
  - KeycardMTFPrivate
  - KeycardGuard
  - GrenadeHE
  - KeycardZoneManager
  - KeycardGuard
  - Radio
  - Ammo9x19
  - Ammo12gauge
  - Ammo44cal
  - Ammo556x45
  - Ammo762x39
  - GrenadeFlash
  - KeycardScientist
  - KeycardJanitor
  - Coin
  - Flashlight
```


# Installation

**[EXILED 8.0.0](https://github.com/galaxy119/EXILED) must be installed for this to work.**

Place the "SCP1162.dll" file in your Plugins folder.
Windows: ``%appdata%/EXILED/Plugins``.
Linux: ``.config/EXILED/Plugins``.
