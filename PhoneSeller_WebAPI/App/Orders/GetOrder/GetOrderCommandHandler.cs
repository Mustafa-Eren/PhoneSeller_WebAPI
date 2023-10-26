using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Orders.GetOrder
{
    public class GetOrderCommandHandler : IRequestHandler<GetOrderCommand,GetOrderResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetOrderCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<GetOrderResponseModel> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        {
            var order = DbContext.Orders.Include(x=>x.Customer).FirstOrDefault(b => b.Id == request.OrderId);

            if (order == null)
            {
                throw new BadHttpRequestException("order not found");
            }

            return new GetOrderResponseModel
            {
                OrderId = order.Id,
                CustomerName = order.Customer?.CustomerName,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                OrderStatus = (Enums.OrderStatus)order.OrderStatus,
                OrderDescription = order.OrderDescription
            };
        }
    }
}
