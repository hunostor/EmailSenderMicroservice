using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailSenderMicroservice
{
    public class EmailSender : IEmailSender
    {
        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;

        // Get our parameterized configuration
        public EmailSender(string host, int port, bool enableSSL, string userName, string password)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
        }

        // Use our configuration to send the email by using SmtpClient
        public Task SendEmailAsync(string from, string to, string subject, string htmlMessage)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };

            var fromEmail = new MailAddress(from);
            var toEmail = new MailAddress(to);

            return client.SendMailAsync(
                new MailMessage(fromEmail, toEmail) 
                {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = htmlMessage
                }
            );          
        }

        public Task SendEmailAsync(EmailRequest request)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };

            var fromEmail = new MailAddress(request.FromAddress, request.FromDisplay);
            var toEmail = new MailAddress(request.ToAddress, request.ToDisplay);

            return client.SendMailAsync(
                new MailMessage(fromEmail, toEmail)
                {
                    IsBodyHtml = true,
                    Subject = request.Subject,
                    Body = request.HtmlMessage
                }
            );
        }
    }
}
