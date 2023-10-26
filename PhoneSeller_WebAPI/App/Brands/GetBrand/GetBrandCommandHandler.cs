using MediatR;
using PhoneSeller_WebAPI.App.Brands.GetBrands;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.Brands.GetBrand
{
    public class GetBrandCommandHandler:IRequestHandler<GetBrandCommand,GetBrandResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetBrandCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<GetBrandResponseModel> Handle(GetBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = DbContext.Brands.FirstOrDefault(b => b.Id == request.BrandId);

            if (brand == null)
            {
                throw new BadHttpRequestException("brand not found");
            }

            return new GetBrandResponseModel
            {
                ID = brand.Id,
                BrandName = brand.BrandName
            };
        }
    }
}
