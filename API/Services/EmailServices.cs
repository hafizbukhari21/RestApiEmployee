using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace API.Services
{
    public class EmailServices
    {
        
        public static void SendEmail(string emailTo, string subject, string body)
        {
            var client = new SmtpClient("smtp.ethereal.email", 587)
            {
                Credentials = new NetworkCredential("jane.fritsch62@ethereal.email", "t8R28Wv47gjQaqMhFq"),
                EnableSsl = true
            };
            client.Send("jane.fritsch62@ethereal.email", "hafiz.210398@gmail.com", subject, body);
         
        }
        
    }
}
