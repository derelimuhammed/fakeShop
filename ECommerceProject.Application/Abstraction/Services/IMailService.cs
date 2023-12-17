using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace ECommerceProject.Application.Abstraction.Services
{
    public interface IMailService
    {
        public Task SendMailAsync(string[] tos, string subject, string body);
        public Task SendPasswordResetMailAsync(string to, string userId, string resetToken);
       
    }
}
