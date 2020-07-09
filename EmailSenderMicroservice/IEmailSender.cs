using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSenderMicroservice
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string from, string to, string subject, string htmlMessage);
        Task SendEmailAsync(EmailRequest request);
    }
}
