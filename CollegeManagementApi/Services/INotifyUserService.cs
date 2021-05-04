using CollegeManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementApi.Services
{
    public interface INotifyUserService
    {
        void NotifyNewUser(Teacher t);
        void NotifyNewUser(Student s);
    }
    public class NotifyUserService:INotifyUserService
    {
        private IMailService notifyer;
        public NotifyUserService(IMailService notifyer)
        {
            this.notifyer = notifyer;
        }
        public void NotifyNewUser(Teacher t)
        {
            string subject = GetWelcomeSubject();
            string body = GetWelcomeBody(t.Name);
            notifyer.SendMail(t.Emailid, subject, body);
        }
        public void NotifyNewUser(Student s)
        {
            string subject = GetWelcomeSubject();
            string body = GetWelcomeBody(s.Name);
            notifyer.SendMail(s.Emailid, subject, body);
        }
        private string GetWelcomeSubject()
        {
            return "Welcome To VIT Family";
        }
        private string GetWelcomeBody(string Name)
        {
            string body = $"<html><body><h1>Hi {Name},</h1><h2>Welcome To VIT</h2>Congratulations on your admission to VIT, and welcome to this incredible, multi-generational and inclusive community of learning. I am thrilled that we will have the opportunity to begin a new year of our academic lives together. During my three years as Dean of VIT College, I have seen our community come together in good times and in challenging times — pushing one another to become more thoughtful and engaged citizens and supporting one another in times of need. In the days before you arrive on campus, I write to share my thoughts with you about the community you are about to enter, and the journey you are set to begin.<p>When you arrive on campus, I look forward to having many discussions with you about your education and your vision for our community. As we work together to write the next chapter of VIT’s history to ensure its excellence in the 21st century, we are going to make mistakes. Making change like learning is hard. It is not always seamless. It can be messy. But this is the nature of our work. I know that by working together, we can positively shape our community and sustain VIT’s bright future.</p><p>Warmly,<br>Dean Khurana</p></body></html>";
            return body;
        }
    }
}
