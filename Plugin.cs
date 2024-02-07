using System;
using Exiled.API.Features;

namespace SCP1162;

public class SCP1162 : Plugin<Config>
{
    public override string Prefix => "SCP-1162";
    public override string Name => "SCP-1162";
    public override string Author => "xRoier";

    public static SCP1162 Instance;
    public EventHandlers EventHandlers = new();
    
    public override Version Version { get; } = new(8, 0, 0);
    public override Version RequiredExiledVersion { get; } = new(8, 0, 0);

    public override void OnEnabled()
    {
        Instance = this;
        Exiled.Events.Handlers.Player.DroppingItem += EventHandlers.OnItemDropped;
        Exiled.Events.Handlers.Player.Died += EventHandlers.OnPlayerDied;
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Instance = null;
        Exiled.Events.Handlers.Player.DroppingItem -= EventHandlers.OnItemDropped;
        Exiled.Events.Handlers.Player.Died -= EventHandlers.OnPlayerDied;
        EventHandlers = null;
        base.OnDisabled();
    }
}