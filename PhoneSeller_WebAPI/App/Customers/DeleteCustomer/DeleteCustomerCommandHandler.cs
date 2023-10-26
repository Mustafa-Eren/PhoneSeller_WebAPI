using MediatR;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand,DeleteCustomerResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public DeleteCustomerCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<DeleteCustomerResponseModel> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = DbContext.Customers.FirstOrDefault(b => b.Id == request.CustomerId);

            if (customer == null)
            {
                throw new BadHttpRequestException("customer not found");
            }

            DbContext.Customers.Remove(customer);
            await DbContext.SaveChangesAsync();
            return new DeleteCustomerResponseModel { IsDelete = true };
        }
    }
}
