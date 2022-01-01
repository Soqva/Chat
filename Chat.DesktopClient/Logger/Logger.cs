using NLog;
using NLog.Config;
using NLog.Targets;

namespace Chat.DesktopClient.Logger
{
    public class Logger
    {
        private static NLog.Logger LOGGER;

        static Logger()
        {
            InitializeLogger();
        }

        private Logger()
        {

        }

        private static void InitializeLogger()
        {
            LoggingConfiguration config = new NLog.Config.LoggingConfiguration();
            FileTarget logfile = new NLog.Targets.FileTarget("logfile")
            {
                FileName = "logfile.txt"
            };

            config.AddRule(LogLevel.Info, LogLevel.Error, logfile);
            LogManager.Configuration = config;

            LOGGER = LogManager.GetCurrentClassLogger();
        }

        public static NLog.Logger GetLogger()
        {
            return LOGGER;
        }
    }
}
