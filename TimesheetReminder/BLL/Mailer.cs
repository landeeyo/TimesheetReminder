using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace TimesheetReminder.BLL
{
    public static class Mailer
    {
        /// <summary>
        /// Quite standard sendmail method
        /// </summary>
        /// <param name="Message">MailMessage object</param>
        private static void SendMail(MailMessage Message)
        {
            SmtpClient client = new SmtpClient();
            client.Host = ConfigurationManager.AppSettings["address"];
            client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["ssl"]);
            client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["pass"]);
            client.Send(Message);
        }

        /// <summary>
        /// Reads recipients from config file
        /// </summary>
        /// <returns></returns>
        private static MailAddressCollection CollectRecipients()
        {
            var recipients = ConfigurationManager.AppSettings["recipients"];
            var recipientsList = recipients.Split(';').ToList();
            var data = new MailAddressCollection();
            foreach (var recipient in recipientsList)
            {
                data.Add(new MailAddress(recipient));
            }
            return data;
        }

        /// <summary>
        /// Prepares reminding e-mail according to service cofiguration
        /// </summary>
        /// <returns>MailMessage object</returns>
        private static MailMessage PrepareMail()
        {
            var from = new MailAddress(ConfigurationManager.AppSettings["sender"]);
            var data = new MailMessage(from, from);
            foreach (var recipient in CollectRecipients())
            {
                data.To.Add(recipient);
            }
            data.Subject = ConfigurationManager.AppSettings["subject"];
            IPhotoExtractor photoExtractor = new TumblrPhotoExtractor();
            string photoAddress = photoExtractor.ExtractPhoto(ConfigurationManager.AppSettings["page"]);
            string body = "<html><body>" + ConfigurationManager.AppSettings["body"] + "<br><br>" + "<img src = \"" + photoAddress + "\"></body></html>";
            data.Body = body;
            data.IsBodyHtml = true;
            return data;
        }

        /// <summary>
        /// Sends emails to recipients at time specified in configuration
        /// </summary>
        private static void SendMailAtHourLoop()
        {
            while (true)
            {
                string executionTime = ConfigurationManager.AppSettings["hour"];
                int executionHour;
                int executionMinute;
                string[] splittedTime = executionTime.Split(':');
                if (!int.TryParse(splittedTime[0], out executionHour))
                {
                    string exceptionMessage = "Unable to extract hour from time given in configuration";
                    Logger.Log(exceptionMessage);
                    throw new Exception(exceptionMessage);
                }
                if (!int.TryParse(splittedTime[1], out executionMinute))
                {
                    string exceptionMessage = "Unable to extract minute from time given in configuration";
                    Logger.Log(exceptionMessage);
                    throw new Exception(exceptionMessage);
                }
                if (DateTime.Now.Hour == executionHour && DateTime.Now.Minute == executionMinute)
                {
                    Logger.Log("Sending reminding e-mail to recipients.");
                    SendMail(PrepareMail());
                }
                Thread.Sleep(60000);
            }
        }

        public static void StartMailer()
        {
            Logger.Log("Initializing mailing thread.");
            Thread mailerThread = new Thread(new ThreadStart(SendMailAtHourLoop));
            Logger.Log("Starting mailing thread.");
            mailerThread.Start();
        }
    }
}
