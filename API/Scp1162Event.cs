using Exiled.Events;
using Exiled.Events.Extensions;

namespace SCP1162.API
{
    public static class Scp1162Event
    {
        public static event Events.CustomEventHandler<UsingScp1162EventArgs> UsingScp1162;
        public static void OnUsingScp1162(UsingScp1162EventArgs ev) => UsingScp1162.InvokeSafely(ev);
    }
}