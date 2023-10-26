using PhoneSeller_WebAPI.Enums;

namespace PhoneSeller_WebAPI.App.Orders.GetOrders
{
    public class GetOrdersResponseModel
    {
        public int OrderId { get; set; }

        public string? CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string? OrderDescription { get; set; }
    }
}
