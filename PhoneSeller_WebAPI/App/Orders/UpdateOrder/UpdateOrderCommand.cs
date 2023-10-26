using MediatR;

namespace PhoneSeller_WebAPI.App.Orders.UpdateOrder
{
    public class UpdateOrderCommand :IRequest<UpdateOrderResponseModel>
    {
        public int? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalPrice { get; set; }
        public int? OrderStatus { get; set; }
        public string? OrderDescription { get; set; }

    }
}
