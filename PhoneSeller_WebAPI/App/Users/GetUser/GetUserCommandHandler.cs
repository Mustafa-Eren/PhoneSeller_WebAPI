using MediatR;
using PhoneSeller_WebAPI.App.Accessor;
using PhoneSeller_WebAPI.App.Security;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Security;
using System.Security.Claims;

namespace PhoneSeller_WebAPI.App.Users.GetUser
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, GetUserResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        public IUserAccessor userAccessor { get; }
        private readonly IConfiguration configuration;
        public GetUserCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration,IUserAccessor _userAccessor)
        {
            DbContext = _dbContext;
            configuration = _configuration;
            userAccessor = _userAccessor;
        }
        public Task<GetUserResponseModel> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var user = userAccessor.User.Identity.Name.ToString();

            if (user == null)
            {
                throw new BadHttpRequestException("user not found");
            }

            var role = userAccessor.User.FindFirstValue(ClaimTypes.Role);
            var userId = Convert.ToInt32(userAccessor.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var email = DbContext.Users.FirstOrDefault(x => x.Id == userId).Email;

            return Task.FromResult(new GetUserResponseModel
            {
                ID = userId,
                UserName = user,
                Email = email,
                Permission = role
            });
        }
    }
}
