using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using TimesheetReminder.BLL;
using System.Net.Mail;

namespace TimesheetReminder
{
    public partial class TSReminder : ServiceBase
    {
        public TSReminder()
        {
            InitializeComponent();
            if (Logging.IsLoggingEnabled)
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
            Logging.Log(this, "TimesheetReminder service has been started.");
        }

        protected override void OnStop()
        {
            Logging.Log(this,"TimesheetReminder service has been stopped.");
        }
    }
}
