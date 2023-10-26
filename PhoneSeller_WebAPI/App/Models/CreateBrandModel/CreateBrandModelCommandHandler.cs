using MediatR;
using PhoneSeller_WebAPI.App.Brands.CreateBrand;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Models.CreateBrandModel
{
    public class CreateBrandModelCommandHandler :IRequestHandler<CreateBrandModelCommand,CreateBrandModelResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public CreateBrandModelCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<CreateBrandModelResponseModel> Handle(CreateBrandModelCommand request, CancellationToken cancellationToken)
        {
            var newModel = new Model
            {
                BrandId = request.BrandId,
                ModelName = request.ModelName,
            };

            DbContext.Models.Add(newModel);

            DbContext.SaveChanges();

            return new CreateBrandModelResponseModel
            {
                BrandId = request.BrandId,
                ModelId = newModel.Id,
                ModelName = newModel.ModelName
            };

        }
    }
}
