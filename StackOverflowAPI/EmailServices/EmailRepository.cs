using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using StackOverflowAPI.Request.Email;
using MailKit.Net.Smtp;

namespace StackOverflowAPI.EmailServices
{
    public class EmailRepository : EmailInterface
    {
        private readonly IConfiguration _configuration;
        public EmailRepository(IConfiguration configurations)
        {
            _configuration = configurations;    
        }

        public void sendEmail(EmailDto emailDto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(emailDto.To));
           

            email.Subject = emailDto.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailDto.Body };

            var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUsername").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
