using EXILED;

namespace SCP1162
{
    public class Plugin : EXILED.Plugin
    {
        public EventHandlers EventHandlers;

        public override string getName => "SCP1162";
        public string msg1162 = "";


        public override void OnEnable()
        {
            bool isEnabled = Config.GetBool("scp1162_enable", true);
            if (!isEnabled)
            {
                Log.Info("Plugin is disabled by config, ignoring it.");
                return;
            }
            else if (isEnabled)
            {
                Log.Info("SCP1162 has been enabled.");
                msg1162 = Config.GetString("scp1162_msg", "<i>You try to drop the item through <color=yellow>SCP-1162</color> to get another item...</i>");
                EventHandlers = new EventHandlers(this);
                Events.ItemDroppedEvent += EventHandlers.OnItemDrop;
            }
        }

        public override void OnDisable()
        {
            Log.Info("SCP1162 has been disabled.");
            Events.ItemDroppedEvent -= EventHandlers.OnItemDrop;
            EventHandlers = null;
        }

        public override void OnReload()
        {
        }
    }
}
