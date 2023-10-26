using MediatR;
using PhoneSeller_WebAPI.App.Brands.GetBrand;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Brands.CreateBrand
{
    public class CreateBrandCommandHandler :IRequestHandler<CreateBrandCommand,CreateBrandResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public CreateBrandCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<CreateBrandResponseModel> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var newBrand = new Brand
            {
                BrandName = request.BrandName,
            };

            DbContext.Brands.Add(newBrand);

            DbContext.SaveChanges();

            return new CreateBrandResponseModel
            {
                BrandId = newBrand.Id,
                BrandName = newBrand.BrandName
            };

        }
    }
}
