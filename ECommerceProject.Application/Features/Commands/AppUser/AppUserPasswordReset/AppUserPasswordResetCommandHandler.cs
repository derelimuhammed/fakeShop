using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Abstraction.Services;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Commands.AppUser.AppUserPasswordReset
{
    public class AppUserPasswordResetCommandHandler: IRequestHandler<AppUserPasswordResetCommandRequest, Result>
    {
        private readonly IAuthService _authService;

        public AppUserPasswordResetCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(AppUserPasswordResetCommandRequest request, CancellationToken cancellationToken)
        {
            await _authService.PasswordResetAsync(request.Email);
            return new SuccessResult("E-mail Gönderildi");
        }
    }
}
