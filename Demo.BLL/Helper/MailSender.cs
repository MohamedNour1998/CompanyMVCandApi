using Demo.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Helper
{
   public static class MailSender
    {
        public static string MailSend(MailVM model)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");
                smtp.Send("as8338873@gmail.com", model.Mail, model.Title, model.Message);

                var result = "Mail send sucessfully";
                return result;
            }
            catch (Exception ex)
            {
                var result = "Failed";
                return result;
            }
        }
    }
}
