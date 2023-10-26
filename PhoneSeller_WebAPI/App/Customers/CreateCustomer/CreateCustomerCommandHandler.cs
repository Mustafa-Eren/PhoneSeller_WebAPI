using MediatR;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Customers.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public CreateCustomerCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<CreateCustomerResponseModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = new Customer
            {
                CustomerName = request.CustomerName,
                CreatedAt = request.CreatedAt,
                CreatedBy = request.CreatedBy,
                Email= request.Email
            };

            DbContext.Customers.Add(newCustomer);

            DbContext.SaveChanges();

            return new CreateCustomerResponseModel
            {
                ID = newCustomer.Id,
                CustomerName = newCustomer.CustomerName,
                CreatedAt = newCustomer.CreatedAt,
                CreatedBy = DbContext.Users.FirstOrDefault(a => a.Id == newCustomer.CreatedBy).Username,
                Email = newCustomer.Email
            };

        }
    }
}
