using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneSeller_WebAPI.App.Brands.GetBrands;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.Models.GetBrandModels
{
    public class GetBrandModelsCommandHandler : IRequestHandler<GetBrandModelsCommand, BaseListResponse<GetBrandModelsResponseModel>>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetBrandModelsCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<BaseListResponse<GetBrandModelsResponseModel>> Handle(GetBrandModelsCommand request, CancellationToken cancellationToken)
        {
            var modelsList = DbContext.Models.Include(x => x.Brand).Where(x => x.BrandId == request.BrandId).ToList();

            if (request == null || modelsList == null)
            {
                throw new BadHttpRequestException("model list not found");
            }
            var brandModelsList = modelsList.Select(x => new GetBrandModelsResponseModel
            {
                BrandName = x.Brand.BrandName,
                ModelName = x.ModelName
            }).ToList();


            return new BaseListResponse<GetBrandModelsResponseModel>
            {
                Items = brandModelsList,
                Total = brandModelsList.Count()
            };
        }
    }
}
