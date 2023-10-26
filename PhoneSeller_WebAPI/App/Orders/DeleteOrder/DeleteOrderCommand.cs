using MediatR;

namespace PhoneSeller_WebAPI.App.Orders.DeleteOrder
{
    public class DeleteOrderCommand:IRequest<DeleteOrderResponseModel>
    {
        public int OrderId { get; set; }

    }
}
