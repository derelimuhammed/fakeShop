using ECommerceProject.Domain.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Application.Abstraction.Services
{
    public interface IAppUserService
    {
        public Task<IdentityResult> CreateAsync(AppUser user, string password);
        public Task<AppUser?> FindByNameAsync(string userName);
    }
}
