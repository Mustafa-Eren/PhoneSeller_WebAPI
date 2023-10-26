using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneSeller_WebAPI.App.Security;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Response;
using PhoneSeller_WebAPI.Security;

namespace PhoneSeller_WebAPI.App.Brands.GetBrands
{
    public class GetBrandsCommandHandler : IRequestHandler<GetBrandsCommand, BaseListResponse<GetBrandsResponseModel>>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetBrandsCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<BaseListResponse<GetBrandsResponseModel>> Handle(GetBrandsCommand request, CancellationToken cancellationToken)
        {
            var brandList = DbContext.Brands.ToList().Select(x => new GetBrandsResponseModel
            {
                ID = x.Id,
                BrandName = x.BrandName
            }).ToList();


            return new BaseListResponse<GetBrandsResponseModel>
            {
                Items = brandList,
                Total = brandList.Count()
                //BrandName = "dsbvfdd"
            };
        }
    }
}
