using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Abstraction.Services;
using ECommerceProject.Domain.Concrete;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;


namespace ECommerceProject.Infrastructure.Services.Mail
{
    public class MailService:IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body)
        { 
            await SendMailAsync(new[] { to }, subject, body );
        }

        public  async Task SendMailAsync(string[] tos, string subject, string body)
        {
            MimeMessage mimeMessage = new();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("E-Commerce", "quizelet@gmail.com");
            foreach (var to in tos)
            {
             MailboxAddress mailboxAddressTo = new MailboxAddress("User", to);
             mimeMessage.To.Add(mailboxAddressTo);
            }
            mimeMessage.From.Add(mailboxAddressFrom);
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            mimeMessage.Subject = subject;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            SmtpClient smtp = new();
           await smtp.ConnectAsync(_configuration["Mail:Host"],int.Parse(_configuration["Mail:Port"]), false);
           await smtp.AuthenticateAsync(_configuration["Mail:Username"], _configuration["Mail:Password"]);
           await smtp.SendAsync(mimeMessage);
           await smtp.DisconnectAsync(true);
        }
        
        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {string resetLink = $"{_configuration["ClientUrl"]}/update-password/{userId}/{resetToken}";

            StringBuilder mail = new();
            mail.AppendLine("<html><body>");
            mail.AppendLine($"<p>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.</p>");
            mail.AppendLine($"<p><strong><a target=\"_blank\" href=\"{resetLink}\">Yeni şifre talebi için tıklayınız...</a></strong></p>");
            mail.AppendLine("<p><span style=\"font-size:12px;\">NOT: Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span></p>");
            mail.AppendLine("<p>Saygılarımızla...</p>");
            mail.AppendLine("</body></html>");

            await SendMailAsync(to, "Şifre Yenileme Talebi", mail.ToString());
        }
    }
}
