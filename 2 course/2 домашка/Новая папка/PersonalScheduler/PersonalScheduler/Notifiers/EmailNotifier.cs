using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace PersonalScheduler.Notifiers
{
    public class EmailNotifier:INotifier
    {
        public void Notify(ScheduledEvent sv)
        {
            //try
            //{
                MailMessage mail = new MailMessage(sv.Email, sv.SenderEmail, "Event comes!", string.Format("{0} in {1}\n{2}", sv.Name, sv.Place, sv.Description));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(sv.Email, sv.Password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            //}
            //catch
            //{
            //    throw new Exception("No Internet connection or invalid email data");
            //}
        }
    }
}
