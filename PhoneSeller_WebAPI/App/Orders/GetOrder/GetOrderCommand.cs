using MediatR;

namespace PhoneSeller_WebAPI.App.Orders.GetOrder
{
    public class GetOrderCommand : IRequest<GetOrderResponseModel>
    {
        public int OrderId { get; set; }
    }
}
