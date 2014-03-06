using System.ServiceProcess;
using TimesheetReminder.BLL;

namespace TimesheetReminder
{
    public partial class TSReminder : ServiceBase
    {
        public TSReminder()
        {
            InitializeComponent();
            Logger.Init(this);
            if (Logger.IsLoggingEnabled)
            {
                if (!System.Diagnostics.EventLog.SourceExists("TimesheetReminder"))
                {
                    System.Diagnostics.EventLog.CreateEventSource(
                        "TimesheetReminder", "Application");
                }
                TSEventLog.Source = "TimesheetReminder";
                TSEventLog.Log = "Application";
            }
        }

        protected override void OnStart(string[] args)
        {
            Logger.Log("TimesheetReminder service has been started.");
            Mailer.StartMailer();
        }

        protected override void OnStop()
        {
            Logger.Log("TimesheetReminder service has been stopped.");
        }
    }
}
