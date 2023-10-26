using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Customers.CreateCustomer
{
    public class CreateCustomerCommand:IRequest<CreateCustomerResponseModel>
    {
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; }
        [Required]
        public int? CreatedBy { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
