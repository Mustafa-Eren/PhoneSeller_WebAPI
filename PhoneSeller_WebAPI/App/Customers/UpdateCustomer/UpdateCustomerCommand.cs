using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Customers.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<UpdateCustomerResponseModel>
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? CreatedBy { get; set; }
        public string? Email { get; set; }
    }
}
