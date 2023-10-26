using MediatR;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Customers.GetCustomer
{
    public class GetCustomerCommandHandler :IRequestHandler<GetCustomerCommand,GetCustomerResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetCustomerCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<GetCustomerResponseModel> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = DbContext.Customers.FirstOrDefault(b => b.Id == request.CustomerId);

            if (customer == null)
            {
                throw new BadHttpRequestException("customer not found");
            }

            return new GetCustomerResponseModel
            {
                ID = customer.Id,
                CustomerName = customer.CustomerName,
                CreatedAt = customer.CreatedAt,
                CreatedBy = DbContext.Users.FirstOrDefault(a => a.Id == customer.CreatedBy).Username,
                Email = customer.Email
            };
        }
    }
}
