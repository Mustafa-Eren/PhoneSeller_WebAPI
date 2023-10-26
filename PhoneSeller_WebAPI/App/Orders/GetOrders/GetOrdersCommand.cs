using MediatR;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.Orders.GetOrders
{
    public class GetOrdersCommand:IRequest<BaseListResponse<GetOrdersResponseModel>>
    {
    }
}
