using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResponseModel>
    {
        //[Required]
        //public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
