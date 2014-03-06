using System;
using System.Configuration;

namespace TimesheetReminder.BLL
{
    public static class Logger
    {
        /// <summary>
        /// Handle to main app
        /// </summary>
        private static object _senderHandle;

        /// <summary>
        /// Properties which extracts logging enable state from settings
        /// </summary>
        public static bool IsLoggingEnabled
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["log"]);
            }
        }

        /// <summary>
        /// Initialization of logger
        /// </summary>
        /// <param name="sender"></param>
        public static void Init(object sender)
        {
            _senderHandle = sender;
        }

        /// <summary>
        /// Basic logging method, it logs to windows eventlog
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            if (IsLoggingEnabled)
            {
                if (_senderHandle == null)
                {
                    throw new Exception("Logger has not been initialized.");
                }

                var reminder = _senderHandle as TSReminder;
                
                if (reminder != null)
                {
                    reminder.TSEventLog.WriteEntry(message);
                }
            }
        }
    }
}
