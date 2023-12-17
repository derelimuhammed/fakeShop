using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Commands.AppUser.AppUserPasswordReset
{
    public class AppUserPasswordResetCommandRequest: IRequest<Result>
    {
        public string Email { get; set; }
    }
}
