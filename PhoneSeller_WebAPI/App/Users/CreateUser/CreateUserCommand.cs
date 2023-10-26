using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Users.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserResponseModel>
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; }
        [Required]
        public int? PermissionId { get; set; }
    }
}
