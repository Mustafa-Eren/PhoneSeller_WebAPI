using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneSeller_WebAPI.App.Orders.CreateOrder;
using PhoneSeller_WebAPI.App.Orders.DeleteOrder;
using PhoneSeller_WebAPI.App.Orders.GetCustomerOrders;
using PhoneSeller_WebAPI.App.Orders.GetOrder;
using PhoneSeller_WebAPI.App.Orders.GetOrders;
using PhoneSeller_WebAPI.App.Orders.UpdateOrder;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class OrdersController : BaseController
    {
        [HttpGet("orders")]
        public async Task<BaseListResponse<GetOrdersResponseModel>> GetOrdersList([FromQuery] GetOrdersCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("order/{orderId}")]
        public async Task<GetOrderResponseModel> GetOrder([FromQuery] GetOrderCommand command, [FromRoute] int orderId)
        {
            command.OrderId = orderId;

            return await Mediator.Send(command);
        }

        [HttpGet("customer/{customerId}/orders")]
        public async Task<BaseListResponse<GetCustomerOrdersResponseModel>> GetCustomerOrders([FromQuery] GetCustomerOrdersCommand command, [FromRoute] int customerId)
        {
            command.CustomerId = customerId;

            return await Mediator.Send(command);
        }

        [HttpPost("order")]
        public async Task<CreateOrderResponseModel> CreateOrder([FromQuery] CreateOrderCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("order/{orderId}")]
        public async Task<UpdateOrderResponseModel> UpdateOrder([FromQuery] UpdateOrderCommand command, [FromRoute] int orderId)
        {
            command.OrderId = orderId;

            return await Mediator.Send(command);
        }

        [HttpDelete("order/{orderId}")]
        public async Task<DeleteOrderResponseModel> DeleteOrder([FromQuery] DeleteOrderCommand command, [FromRoute] int orderId)
        {
            command.OrderId = orderId;

            return await Mediator.Send(command);
        }
    }
}
