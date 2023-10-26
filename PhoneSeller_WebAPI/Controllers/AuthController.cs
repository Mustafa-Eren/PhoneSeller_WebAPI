using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneSeller_WebAPI.App.Users.CreateUser;
using PhoneSeller_WebAPI.App.Users.GetUser;
using PhoneSeller_WebAPI.App.Users.UpdateUser;

namespace PhoneSeller_WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class AuthController : BaseController
    {
        [HttpGet("/auth/user")]
        public async Task<GetUserResponseModel> GetUser([FromQuery] GetUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("/auth/register")]
        public async Task<CreateUserResponseModel> CreateUser([FromQuery] CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("/auth/user")]
        public async Task<UpdateUserResponseModel> UpdateUser([FromQuery] UpdateUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
