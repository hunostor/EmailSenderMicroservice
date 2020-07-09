using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSenderMicroservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SenderController : ControllerBase
    {
        private readonly IEmailSender _sender;

        public SenderController(IEmailSender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpPost]
        public async Task<IActionResult> Send(EmailRequest request)
        {
            await _sender.SendEmailAsync(request);

            return Ok(new { message = "Email sent." });
        }
    }
}
