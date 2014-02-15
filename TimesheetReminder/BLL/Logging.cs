using System;
using System.Configuration;

namespace TimesheetReminder.BLL
{
    public static class Logging
    {
        public static bool IsLoggingEnabled
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings["log"]);
            }
        }

        public static void Log(object sender, string message)
        {
            var reminder = sender as TSReminder;
            if (reminder != null)
            {
                reminder.TSEventLog.WriteEntry(message);
            }
        }
    }
}
