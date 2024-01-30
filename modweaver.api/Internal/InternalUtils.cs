using NLog;

namespace modweaver.api.Internal
{
    public class InternalUtils
    {
        internal static Logger Logger;
        public static void init()
        {
            // call any setup here
            Logger.Info("InternalUtils initialized!");
        }
    }
}