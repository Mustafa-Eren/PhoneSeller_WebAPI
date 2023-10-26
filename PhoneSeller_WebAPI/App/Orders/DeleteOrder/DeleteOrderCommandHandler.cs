using MediatR;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Orders.DeleteOrder
{
    public class DeleteOrderCommandHandler:IRequestHandler<DeleteOrderCommand,DeleteOrderResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public DeleteOrderCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<DeleteOrderResponseModel> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = DbContext.Orders.FirstOrDefault(b => b.Id == request.OrderId);

            if (order == null)
            {
                throw new BadHttpRequestException("order not found");
            }

            DbContext.Orders.Remove(order);
            await DbContext.SaveChangesAsync();
            return new DeleteOrderResponseModel
            {
                IsDelete = true
            };
        }
    }
}
