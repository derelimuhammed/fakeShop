using ECommerceProject.Domain.Ultilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Application.Abstraction.Services
{
    public interface IAuthService
    {
        public Task<Result> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task PasswordResetAsync(string email);
    }
}
