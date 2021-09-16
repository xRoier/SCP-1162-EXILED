[![Github All Releases](https://img.shields.io/github/downloads/xRoier/SCP-1162-EXILED/total?color=blueviolet&style=for-the-badge)]()
# SCP-1162-EXILED

Turn 173 spawn into SCP-1162.
If you drop an item inside the "cage"/room of Scp-173 you will get another one. (Or a corpse).

[![Github All Releases](https://img.shields.io/github/downloads/xRoier/DiscordAutoBanMessage/total?color=blueviolet&style=for-the-badge)]()
# Config
```
scp1162:
# Is the plugin enabled?
  is_enabled: true
  # Use Hints instead of Broadcast?
  use_hints: true
  # Can SCP-1162 spawn corpses?
  can_spawn_corpses: true
  # Change the message that displays when you drop an item through SCP-1162.
  item_drop_message: <i>You try to drop the item through <color=yellow>SCP-1162</color> to get another...</i>
  item_drop_message_duration: 5
  # The list of possible items.
  chances:
  - KeycardO5
  - SCP500
  - MicroHID
  - KeycardNTFCommander
  - KeycardContainmentEngineer
  - SCP268
  - GunCOM15
  - GrenadeFrag
  - SCP207
  - Adrenaline
  - GunUSP
  - KeycardFacilityManager
  - Medkit
  - KeycardNTFLieutenant
  - KeycardSeniorGuard
  - Disarmer
  - KeycardZoneManager
  - KeycardScientistMajor
  - KeycardGuard
  - Radio
  - Ammo556
  - Ammo762
  - Ammo9mm
  - GrenadeFlash
  - WeaponManagerTablet
  - KeycardScientist
  - KeycardJanitor
  - Coin
  - Flashlight
```


# Installation

**[EXILED 2.1.29](https://github.com/galaxy119/EXILED) must be installed for this to work.**

Place the "SCP1162.dll" file in your Plugins folder.
Windows: ``%appdata%/EXILED/Plugins``.
Linux: ``.config/EXILED/Plugins``.
