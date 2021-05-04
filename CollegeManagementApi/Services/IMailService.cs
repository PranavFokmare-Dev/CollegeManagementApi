using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface IMailService
    {
        string SendMail(string to, string subject, string Body = "");
    }
    public class MailService:IMailService
    {
      
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
        }
        public string SendMail(string to, string subject, string Body = "")
        {
            string userState = "Mail State";
            MailMessage mailmessage = new MailMessage("college.management.2021@gmail.com", to, subject, Body);
            mailmessage.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("college.management.2021@gmail.com", "i9WNjgrkKp65");
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            NetworkCredential _NetworkCredentials = new NetworkCredential("college.management.2021@gmail.com", "i9WNjgrkKp65");
            client.SendAsync(mailmessage, userState);
            return "0";
        }

    }

}
