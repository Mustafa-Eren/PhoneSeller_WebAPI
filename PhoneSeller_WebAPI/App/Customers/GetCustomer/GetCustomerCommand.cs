using MediatR;

namespace PhoneSeller_WebAPI.App.Customers.GetCustomer
{
    public class GetCustomerCommand :IRequest<GetCustomerResponseModel>
    {
        public int CustomerId { get; set; }
    }
}
