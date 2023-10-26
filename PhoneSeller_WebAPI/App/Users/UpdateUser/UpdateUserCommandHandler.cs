using MediatR;
using PhoneSeller_WebAPI.App.Accessor;
using PhoneSeller_WebAPI.Models;
using System.Security.Claims;

namespace PhoneSeller_WebAPI.App.Users.UpdateUser
{
    public class UpdateUserCommandHandler :IRequestHandler<UpdateUserCommand,UpdateUserResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public IUserAccessor userAccessor { get; }

        public UpdateUserCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration, IUserAccessor _userAccessor)
        {
            DbContext = _dbContext;
            configuration = _configuration;
            userAccessor = _userAccessor;
        }
        public async Task<UpdateUserResponseModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(userAccessor.User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (userId == null)
            {
                throw new BadHttpRequestException("user not found");
            }
            var user = DbContext.Users.FirstOrDefault(b => b.Id == userId);

            
            _ = request.UserName == null ? user.Username = user.Username : user.Username = request.UserName;
            _ = request.Email == null ? user.Email = user.Email : user.Email = request.Email;
            _ = request.Password == null ? user.Password = user.Password : user.Password = request.Password;
            DbContext.Users.Update(user);
            await DbContext.SaveChangesAsync();

            return new UpdateUserResponseModel { IsSuccess = true };
        }
    }
}
