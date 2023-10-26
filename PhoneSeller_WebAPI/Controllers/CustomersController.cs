using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneSeller_WebAPI.App.Customers.CreateCustomer;
using PhoneSeller_WebAPI.App.Customers.DeleteCustomer;
using PhoneSeller_WebAPI.App.Customers.GetCustomer;
using PhoneSeller_WebAPI.App.Customers.GetCustomers;
using PhoneSeller_WebAPI.App.Customers.UpdateCustomer;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class CustomersController : BaseController
    {
        [HttpGet("customers")]
        public async Task<BaseListResponse<GetCustomersResponseModel>> GetBrandsList([FromQuery] GetCustomersCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<GetCustomerResponseModel> GetBrand([FromQuery] GetCustomerCommand command, [FromRoute] int customerId)
        {
            command.CustomerId = customerId;

            return await Mediator.Send(command);
        }

        [HttpPost("customer")]
        public async Task<CreateCustomerResponseModel> CreateBrand([FromQuery] CreateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("customer/{customerId}")]
        public async Task<UpdateCustomerResponseModel> UpdateBrand([FromQuery] UpdateCustomerCommand command, [FromRoute] int customerId)
        {
            command.CustomerId = customerId;

            return await Mediator.Send(command);
        }

        [HttpDelete("customer/{customerId}")]
        public async Task<DeleteCustomerResponseModel> DeleteBrand([FromQuery] DeleteCustomerCommand command, [FromRoute] int customerId)
        {
            command.CustomerId = customerId;

            return await Mediator.Send(command);
        }
    }
}
