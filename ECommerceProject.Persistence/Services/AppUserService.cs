using ECommerceProject.Application.Abstraction.Services;
using ECommerceProject.Application.Helpers;
using ECommerceProject.Domain.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ECommerceProject.Persistence.Services
{
    internal class AppUserService:UserManager<AppUser>,IAppUserService
    {
        private readonly IEmailCodeHelper _emailCodeHelper;
        public AppUserService(IUserStore<AppUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<AppUser> passwordHasher, IEnumerable<IUserValidator<AppUser>> userValidators, IEnumerable<IPasswordValidator<AppUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<AppUser>> logger, IEmailCodeHelper emailCodeHelper) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _emailCodeHelper = emailCodeHelper;
        }

        

        public override async Task<IdentityResult> CreateAsync(AppUser user, string password)
        {
            user.ConfirmCode = await _emailCodeHelper.GenerateCode();
            return await base.CreateAsync(user, password);
        }

        public override Task<AppUser?> FindByNameAsync(string userName)
        {
            return base.FindByNameAsync(userName);
        } 
        
    }
}
