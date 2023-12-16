using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceProject.Application.Abstraction.Services;
using ECommerceProject.Domain.Ultilities.Results;
using MailKit.Net.Smtp;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MimeKit;

namespace ECommerceProject.Application.Features.Commands.AppUser.AppUserRegister
{
    public class AppUserRegisterCommandHandler: IRequestHandler<AppUserRegisterCommandRequest,AppUserRegisterCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserService _userManager;

        public AppUserRegisterCommandHandler(IMapper mapper, IAppUserService userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AppUserRegisterCommandResponse> Handle(AppUserRegisterCommandRequest request, CancellationToken cancellationToken)
        {
          var appUser=  _mapper.Map<AppUserRegisterCommandRequest, Domain.Concrete.AppUser>(request);
          var result = await _userManager.CreateAsync(appUser, request.Password);
          var registeredUser= _mapper.Map<AppUserRegisterCommandResponse>(result);
          if (result.Succeeded)
          {
              var IdentityUser= await _userManager.FindByNameAsync(request.UserName);
              if (IdentityUser!=null)
              {
                  registeredUser.Id = IdentityUser.Id;
                  registeredUser.ConfirmCode = IdentityUser.ConfirmCode;
                  return registeredUser;
              }
          }
          return registeredUser;
        }
        
    }
}
