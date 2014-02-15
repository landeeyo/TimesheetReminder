namespace TimesheetReminder
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TSReminderProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.TSReminderInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // TSReminderProcessInstaller
            // 
            this.TSReminderProcessInstaller.Password = null;
            this.TSReminderProcessInstaller.Username = null;
            this.TSReminderProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller1_AfterInstall);
            // 
            // TSReminderInstaller
            // 
            this.TSReminderInstaller.ServiceName = "TimesheetReminder";
            this.TSReminderInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.TSReminderProcessInstaller,
            this.TSReminderInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller TSReminderProcessInstaller;
        private System.ServiceProcess.ServiceInstaller TSReminderInstaller;
    }
}