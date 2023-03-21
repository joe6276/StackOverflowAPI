using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using StackOverflowAPI.EmailServices;
using StackOverflowAPI.Request.Email;
using System.Security.Cryptography.X509Certificates;

namespace StackOverflowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailInterface _emailInterface;
        public EmailController(EmailInterface emailInterface)
        {
            _emailInterface= emailInterface;
        }

        [HttpPost]

        public async Task<ActionResult<string>> sendEmail(EmailDto email )
        {
          _emailInterface.sendEmail(email);
            return Ok("Done");
        }
    }
}
