using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhoneSeller_WebAPI.App.Accessor;
using PhoneSeller_WebAPI.App.Security;
using PhoneSeller_WebAPI.App.Security.LogOut;
using PhoneSeller_WebAPI.Security;
using System.Security.Claims;

namespace PhoneSeller_WebAPI.Controllers
{
    //[Route("aut/login/[controller]")]
    [ApiController]

    public class TokenController : BaseController
    {
        private readonly IUserAccessor userAccessor;
        public TokenController(IUserAccessor _userAccessor)
        {
            userAccessor = _userAccessor;
        }

        [HttpPost("aut/login/[controller]")]
        public async Task<IActionResult> Login([FromBody] TokenCommand command)
        {
            //TokenCommand token = TokenCommandHandler.CreateToken(_configuration);


            return Ok( await this.Mediator.Send(command));
        }

        [HttpPost("aut/logout/[controller]")]
        public async Task<IActionResult> Logout([FromBody] LogOutCommand command)
        {
            //TokenCommand token = TokenCommandHandler.CreateToken(_configuration);
            HttpContext.Request.Headers.Remove("Authorization");
            //var identities = userAccessor.User.Identity as ClaimsIdentity;
            //if (identities == null)
            //{
            //    throw new BadHttpRequestException("identity is null");
            //}

            //foreach (var item in identities.Claims)
            //{
            //    identities.TryRemoveClaim(item);
            //}

            return Ok(await this.Mediator.Send(command));
        }
    }
}
