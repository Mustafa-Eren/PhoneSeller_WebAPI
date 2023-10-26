using MediatR;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand,UpdateCustomerResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public UpdateCustomerCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<UpdateCustomerResponseModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = DbContext.Customers.FirstOrDefault(b => b.Id == request.CustomerId);

            if (customer == null)
            {
                throw new BadHttpRequestException("customer not found");
            }
            _ = request.CustomerName == null ? customer.CustomerName = customer.CustomerName : customer.CustomerName = request.CustomerName;
            _ = request.CreatedBy == null ? customer.CreatedBy = customer.CreatedBy : customer.CreatedBy = request.CreatedBy;
            _ = request.Email == null ? customer.Email = customer.Email : customer.Email = request.Email;
            DbContext.Customers.Update(customer);
            await DbContext.SaveChangesAsync();

            return new UpdateCustomerResponseModel { IsSuccess = true };
        }
    }
}
