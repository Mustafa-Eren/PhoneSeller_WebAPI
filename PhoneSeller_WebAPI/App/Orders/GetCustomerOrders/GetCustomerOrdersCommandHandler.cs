using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneSeller_WebAPI.App.Orders.GetOrders;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.Orders.GetCustomerOrders
{
    public class GetCustomerOrdersCommandHandler :IRequestHandler<GetCustomerOrdersCommand,BaseListResponse<GetCustomerOrdersResponseModel>>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetCustomerOrdersCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<BaseListResponse<GetCustomerOrdersResponseModel>> Handle(GetCustomerOrdersCommand request, CancellationToken cancellationToken)
        {
            var customerOrdersList = DbContext.Orders.Include(x => x.Customer).Where(x=>x.CustomerId==request.CustomerId).ToList().Select(x => new GetCustomerOrdersResponseModel
            {
                OrderId = x.Id,
                CustomerName = x.Customer?.CustomerName,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                OrderStatus = (Enums.OrderStatus)x.OrderStatus,
                OrderDescription = x.OrderDescription
            }).ToList();


            return new BaseListResponse<GetCustomerOrdersResponseModel>
            {
                Items = customerOrdersList,
                Total = customerOrdersList.Count()
            };
        }
    }
}
