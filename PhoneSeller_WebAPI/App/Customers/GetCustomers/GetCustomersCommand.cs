using MediatR;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.Customers.GetCustomers
{
    public class GetCustomersCommand :IRequest<BaseListResponse<GetCustomersResponseModel>>
    {
    }
}
