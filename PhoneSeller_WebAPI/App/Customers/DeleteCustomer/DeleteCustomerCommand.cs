using MediatR;

namespace PhoneSeller_WebAPI.App.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResponseModel>
    {
        public int CustomerId { get; set; }

    }
}
