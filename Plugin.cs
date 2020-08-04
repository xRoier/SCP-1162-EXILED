using System;
using Player = Exiled.Events.Handlers.Player;
using Exiled.API.Features;

namespace SCP1162_EXI_2._0
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "scp1162";
        public override string Name => "SCP1162";
        public override string Author => "xRoier";
        public EventHandlers EventHandlers;
        public override Version Version { get; } = new Version(2, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 0, 10);
        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;
            Log.Info("SCP1162 has been enabled. - "+Author);
            EventHandlers = new EventHandlers(this);
            Player.ItemDropped += EventHandlers.OnItemDropped;
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
            Log.Info("SCP1162 has been disabled. - " + Author);
            Player.ItemDropped -= EventHandlers.OnItemDropped;
            EventHandlers = null;
        }
        public override void OnReloaded() { }
    }
}
