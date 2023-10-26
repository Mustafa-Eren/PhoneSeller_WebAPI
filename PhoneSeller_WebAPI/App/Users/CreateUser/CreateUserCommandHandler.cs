using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Users.CreateUser
{
    public class CreateUserCommandHandler :IRequestHandler<CreateUserCommand,CreateUserResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public CreateUserCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<CreateUserResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Username = request.UserName,
                Email = request.Email,
                Password = request.Password,
                CreatedAt = request.CreatedAt
            };

            DbContext.Users.Add(newUser);
            
            DbContext.SaveChanges();

            var newPermission = new UserPermission
            {
                UserId = newUser.Id,
                PermissionId = request.PermissionId
            };

            DbContext.UserPermissions.Add(newPermission);

            DbContext.SaveChanges();

            return new CreateUserResponseModel
            {
                ID = newUser.Id,
                UserName = newUser.Username,
                Email = newUser.Email,
                CreatedAt = newUser.CreatedAt,
                Permission = DbContext.UserPermissions.Include(x=>x.Permission).FirstOrDefault(x=>x.Id==newPermission.Id).Permission.PermissionName
            };

        }
    }
}
