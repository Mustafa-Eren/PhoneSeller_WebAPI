using MediatR;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.Orders.GetCustomerOrders
{
    public class GetCustomerOrdersCommand : IRequest<BaseListResponse<GetCustomerOrdersResponseModel>>
    {
        public int CustomerId { get; set; }

    }
}
