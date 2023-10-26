using MediatR;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Orders.CreateOrder
{
    public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand,CreateOrderResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public CreateOrderCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<CreateOrderResponseModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                OrderStatus = request.OrderStatus,
                OrderDescription=request.OrderDescription
            };

            DbContext.Orders.Add(newOrder);

            DbContext.SaveChanges();

            return new CreateOrderResponseModel
            {
                OrderId = newOrder.Id,
                CustomerName = DbContext.Customers.FirstOrDefault(x=>x.Id==newOrder.CustomerId).CustomerName,
                OrderDate = newOrder.OrderDate,
                TotalPrice=newOrder.TotalPrice,
                OrderStatus= newOrder.OrderStatus,
                OrderDescription= newOrder.OrderDescription
            };

        }
    }
}
