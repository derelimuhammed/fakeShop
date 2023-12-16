using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Application.Features.Commands.AppUser.AppUserRegister
{
    public class AppUserRegisterCommandResponse:IdentityResult
    {
        public Guid Id { get; set; }
        public int? ConfirmCode { get; set; }
    }
}
