using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Domain.Ultilities.Results;
using MediatR;

namespace ECommerceProject.Application.Features.Queries.AppUser.AppUserLogin
{
    public class AppUsersLoginQueryRequest:IRequest<Result>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
