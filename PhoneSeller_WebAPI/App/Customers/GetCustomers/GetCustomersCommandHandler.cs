using MediatR;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.Customers.GetCustomers
{
    public class GetCustomersCommandHandler : IRequestHandler<GetCustomersCommand, BaseListResponse<GetCustomersResponseModel>>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetCustomersCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<BaseListResponse<GetCustomersResponseModel>> Handle(GetCustomersCommand request, CancellationToken cancellationToken)
        {
            var customerList = DbContext.Customers.ToList().Select(x => new GetCustomersResponseModel
            {
                ID = x.Id,
                CustomerName = x.CustomerName,
                CreatedAt = x.CreatedAt,
                CreatedBy = DbContext.Users.FirstOrDefault(a => a.Id == x.CreatedBy).Username,
                Email = x.Email
            }).ToList();


            return new BaseListResponse<GetCustomersResponseModel>
            {
                Items = customerList,
                Total = customerList.Count()
            };
        }
    }
}
