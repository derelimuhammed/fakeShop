using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Abstraction.Services;
using ECommerceProject.Application.Abstraction.Token;
using ECommerceProject.Infrastructure.Services.Mail;
using ECommerceProject.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceProject.Infrastructure.ServiceRegistrations
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();
        }
    }
}
