using MediatR;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Brands.CreateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public UpdateBrandCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<UpdateBrandResponseModel> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = DbContext.Brands.FirstOrDefault(b => b.Id == request.BrandId);

            if (brand == null)
            {
                throw new BadHttpRequestException("brand not found");
            }

            brand.BrandName = request.BrandName;
            DbContext.Brands.Update(brand);
            await DbContext.SaveChangesAsync();

            return new UpdateBrandResponseModel { IsSuccess = true };
        }
    }
}
