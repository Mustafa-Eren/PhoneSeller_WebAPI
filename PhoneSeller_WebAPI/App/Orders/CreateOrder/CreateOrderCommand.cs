using MediatR;
using PhoneSeller_WebAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResponseModel>
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public int OrderStatus { get; set; }
        [Required]
        public string? OrderDescription { get; set; }
    }
}
