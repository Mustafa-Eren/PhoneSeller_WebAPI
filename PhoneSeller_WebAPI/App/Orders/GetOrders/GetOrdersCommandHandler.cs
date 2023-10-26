using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneSeller_WebAPI.App.Brands.GetBrands;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.Orders.GetOrders
{
    public class GetOrdersCommandHandler : IRequestHandler<GetOrdersCommand, BaseListResponse<GetOrdersResponseModel>>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetOrdersCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<BaseListResponse<GetOrdersResponseModel>> Handle(GetOrdersCommand request, CancellationToken cancellationToken)
        {
            var orderList = DbContext.Orders.Include(x => x.Customer).ToList().Select(x => new GetOrdersResponseModel
            {
                OrderId = x.Id,
                CustomerName = x.Customer?.CustomerName,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                OrderStatus = (Enums.OrderStatus)x.OrderStatus,
                OrderDescription = x.OrderDescription
            }).ToList();


            return new BaseListResponse<GetOrdersResponseModel>
            {
                Items = orderList,
                Total = orderList.Count()
            };
        }
    }
}
