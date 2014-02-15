using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace TimesheetReminder.BLL
{
    public static class Mailing
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
        private static MailAddressCollection GetRecipients()
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
        /// Prepares remainding e-mail according to service cofiguration
        /// </summary>
        /// <returns>MailMessage object</returns>
        private static MailMessage PrepareMail()
        {
            var from = new MailAddress(ConfigurationManager.AppSettings["sender"]);
            var data = new MailMessage(from, from);
            foreach (var recipient in GetRecipients())
            {
                data.To.Add(recipient);
            }
            data.Subject = "Subject of TS Reminder mail";
            data.Body = "Subject of TS Reminder mail";
            return data;
        }

        /// <summary>
        /// Sends emails to recipients at time specified in configuration
        /// </summary>
        public static void SendMailAtHour()
        {
            TimeSpan ts = TimeSpan.Parse(ConfigurationManager.AppSettings["hour"]);
            throw new NotImplementedException();
        }
    }
}
