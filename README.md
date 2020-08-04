# SCP-1162-EXILED

Turn 173 spawn into SCP-1162.
If you drop an item inside the "cage"/room of Scp-173 you will get another one. (Or a corpse).

# Config
```
scp1162:
# Is the plugin enabled?
  is_enabled: true
  # Use Hints instead of Broadcast?
  use_hints: true
  # Change the message that displays when you drop an item through SCP-1162.
  itemdropmessage: <i>You try to drop the item through <color=yellow>SCP-1162</color> to get another...</i>
  itemdropmessageduration: 5
  # The list of items. To add another item, use: ItemName: (LastItemNumber + 1). Ex = GunMP7: 30
  chances:
    KeycardO5: 1
    SCP500: 2
    MicroHID: 3
    KeycardNTFCommander: 4
    KeycardContainmentEngineer: 5
    SCP268: 6
    GunCOM15: 7
    GrenadeFrag: 8
    SCP207: 9
    Adrenaline: 10
    GunUSP: 11
    KeycardFacilityManager: 12
    Medkit: 13
    KeycardNTFLieutenant: 14
    KeycardSeniorGuard: 15
    Disarmer: 16
    KeycardZoneManager: 17
    KeycardScientistMajor: 18
    KeycardGuard: 19
    Radio: 20
    Ammo556: 21
    Ammo762: 22
    Ammo9mm: 23
    GrenadeFlash: 24
    WeaponManagerTablet: 25
    KeycardScientist: 26
    KeycardJanitor: 27
    Coin: 28
    Flashlight: 29
```


# Installation

**[EXILED 2.0](https://github.com/galaxy119/EXILED) must be installed for this to work.**

Place the "SCP1162-v2.0.0.dll" file in your Plugins folder.
Windows: %appdata%/Plugins
Linux: ../.config/Plugins/
