using PhoneSeller_WebAPI.Enums;

namespace PhoneSeller_WebAPI.App.Orders.CreateOrder
{
    public class CreateOrderResponseModel
    {
        public int OrderId { get; set; }

        public string? CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalPrice { get; set; }
        public int? OrderStatus { get; set; }
        public string? OrderDescription { get; set; }
    }
}
