using ECommerceProject.Application.Abstraction.Services;
using ECommerceProject.Application.Helpers;
using ECommerceProject.Application.Repository.Interface.ProductRepo;
using ECommerceProject.Persistence.AppContext;
using ECommerceProject.Persistence.Helpers;
using ECommerceProject.Persistence.Repository.ProductRepo;
using ECommerceProject.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceProject.Persistence.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceAPPIDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IValidatorHelper, ValidatorHelper>();
            services.AddScoped<IEmailCodeHelper,EmailCodeHelper>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
