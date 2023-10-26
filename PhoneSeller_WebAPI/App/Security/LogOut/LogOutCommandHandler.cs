using MediatR;
using PhoneSeller_WebAPI.App.Accessor;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Security;
using System.Security.Claims;

namespace PhoneSeller_WebAPI.App.Security.LogOut
{
    public class LogOutCommandHandler : IRequestHandler<LogOutCommand, LogOutResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public IUserAccessor userAccessor { get; }
        public LogOutCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration,IUserAccessor _userAccessor)
        {
            DbContext = _dbContext;
            configuration = _configuration;
            userAccessor = _userAccessor;
        }
        public Task<LogOutResponseModel> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            
            return Task.FromResult(new LogOutResponseModel
            {
                IsSuccess = true,
            });
        }
    }
}
