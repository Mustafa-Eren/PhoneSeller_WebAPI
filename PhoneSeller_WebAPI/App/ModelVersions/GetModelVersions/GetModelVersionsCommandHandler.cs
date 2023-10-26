using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneSeller_WebAPI.App.Models.GetBrandModels;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.ModelVersions.GetModelVersions
{
    public class GetModelVersionsCommandHandler : IRequestHandler<GetModelVersionsCommand, BaseListResponse<GetModelVersionsResponseModel>>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetModelVersionsCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<BaseListResponse<GetModelVersionsResponseModel>> Handle(GetModelVersionsCommand request, CancellationToken cancellationToken)
        {
            var versionsList = DbContext.ModelVersions.Include(x => x.Model).ThenInclude(a => a.Brand).Where(x => x.ModelId == request.ModelId).ToList();
            if (request == null || versionsList == null)
            {
                throw new BadHttpRequestException("version list not found");
            }
            var brandVerionssList = versionsList.Select(x => new GetModelVersionsResponseModel
            {
                BrandName = x.Model.Brand.BrandName,
                ModelName = x.Model.ModelName,
                StorageCappacity = x.StorageCapacity,
                Price =x.Price,
                StockStatus = (Enums.StockStatus)x.StockStatus
            }).ToList();


            return new BaseListResponse<GetModelVersionsResponseModel>
            {
                Items = brandVerionssList,
                Total = brandVerionssList.Count()
            };
        }
    }
}
