using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Abstraction.Services;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Queries.AppUser.AppUserLogin
{
    public class AppUsersLoginQueryHandler: IRequestHandler<AppUsersLoginQueryRequest, Result>
    {
        private IAuthService _authService;

        public AppUsersLoginQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(AppUsersLoginQueryRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);
            return token;
        }
    }
}
