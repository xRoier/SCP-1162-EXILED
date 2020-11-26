using System;
using EvPlayer = Exiled.Events.Handlers.Player;
using Exiled.API.Features;

namespace SCP1162_EXI_2._0
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "scp1162";
        public override string Name => "SCP1162";
        public override string Author => "xRoier";
        public EventHandlers EventHandlers;
        public override Version Version { get; } = new Version(2, 1, 1);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 18);
        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandlers = new EventHandlers(this);
            EvPlayer.ItemDropped += EventHandlers.OnItemDropped;
            try
            {
                Config.ParseChances();
            }
            catch(Exception e)
            {
                Log.Error($"Item chances parsing fucked up: {e.StackTrace}");
            }
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            EvPlayer.ItemDropped -= EventHandlers.OnItemDropped;
            EventHandlers = null;
        }
    }
}
