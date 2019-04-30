using System.Net;
using System.Net.Mail;

namespace Infrastructure
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string subject, string body)
        {
            var fromAddress = new MailAddress("gftstarter@gmail.com", "GFT Starter");
            var toAddress = new MailAddress("gftstarter@gmail.com", "GFT Starter");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "Gft@2019@1")
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }

    public interface IEmailService
    {
        void SendEmail(string subject, string body);
    }
}