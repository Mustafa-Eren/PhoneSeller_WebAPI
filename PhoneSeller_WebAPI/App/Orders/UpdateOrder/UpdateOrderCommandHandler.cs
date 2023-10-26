using MediatR;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand,UpdateOrderResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public UpdateOrderCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<UpdateOrderResponseModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = DbContext.Orders.FirstOrDefault(b => b.Id == request.OrderId);

            if (order == null)
            {
                throw new BadHttpRequestException("order not found");
            }
            _ = request.OrderDate == null ? order.OrderDate = order.OrderDate : order.OrderDate = request.OrderDate;
            _ = request.TotalPrice == null ? order.TotalPrice = order.TotalPrice : order.TotalPrice = request.TotalPrice;
            _ = request.OrderStatus == null ? order.OrderStatus = order.OrderStatus : order.OrderStatus = request.OrderStatus;
            _ = request.OrderDescription == null ? order.OrderDescription = order.OrderDescription : order.OrderDescription = request.OrderDescription;
            DbContext.Orders.Update(order);
            await DbContext.SaveChangesAsync();

            return new UpdateOrderResponseModel { IsSuccess = true };
        }
    }
}
