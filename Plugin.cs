using System;
using Exiled.API.Features;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;

namespace SCP1162
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "SCP-1162";
        public override string Name => "SCP-1162";
        public override string Author => "xRoier";

        public EventHandlers EventHandlers;
        public override Version Version { get; } = new Version(8, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 0, 0);

        public override void OnEnabled()
        {
            EventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Player.DroppingItem += EventHandlers.OnItemDropped;
            Exiled.Events.Handlers.Player.Died += EventHandlers.OnPlayerDied;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.DroppingItem -= EventHandlers.OnItemDropped;
            Exiled.Events.Handlers.Player.Died -= EventHandlers.OnPlayerDied;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}
