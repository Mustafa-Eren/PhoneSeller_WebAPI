using PhoneSeller_WebAPI.Enums;

namespace PhoneSeller_WebAPI.App.Orders.GetOrder
{
    public class GetOrderResponseModel
    {
        public int OrderId { get; set; }

        public string? CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string? OrderDescription { get; set; }
    }
}
