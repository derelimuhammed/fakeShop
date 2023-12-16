using ECommerceProject.Application.Features.Commands.AppUser.AppUserRegister;
using ECommerceProject.Application.Features.Queries.AppUser.AppUserLogin;
using ECommerceProject.Domain.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
      private readonly UserManager<AppUser> _userManager;
      private readonly MediatR.IMediator _mediator;
      public AppUserController(UserManager<AppUser> userManager, IMediator mediator)
      {
          _userManager= userManager;
          _mediator = mediator;
      }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterCommandRequest appUserRegisterCommandRequest )
        {

            var result = await _mediator.Send(appUserRegisterCommandRequest);
            var jsonResult= JsonConvert.SerializeObject(result);
            if (result.Succeeded)
            {
                return Ok(jsonResult);
            }
            else
            {
                return BadRequest(jsonResult);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Login([FromQuery]AppUsersLoginQueryRequest appUserLoginQueryRequest)
        {
            var result = await _mediator.Send(appUserLoginQueryRequest);
            var jsonResult= JsonConvert.SerializeObject(result);
            if (result.IsSuccess)
            {
                return Ok(jsonResult);
            }
            else
            {
                return BadRequest(jsonResult);
            }
        }
    }
}
