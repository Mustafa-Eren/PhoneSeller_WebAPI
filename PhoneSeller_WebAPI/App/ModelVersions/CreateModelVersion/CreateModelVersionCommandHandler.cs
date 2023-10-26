using MediatR;
using PhoneSeller_WebAPI.App.Models.CreateBrandModel;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.ModelVersions.CreateModelVersion
{
    public class CreateModelVersionCommandHandler : IRequestHandler<CreateModelVersionCommand, CreateModelVersionResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public CreateModelVersionCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<CreateModelVersionResponseModel> Handle(CreateModelVersionCommand request, CancellationToken cancellationToken)
        {
            var newVersion = new ModelVersion
            {
                ModelId = request.ModelId,
                StorageCapacity = request.StorageCapacity,
                Price=request.Price,
                StockStatus =request.StockStatus
            };

            DbContext.ModelVersions.Add(newVersion);

            DbContext.SaveChanges();

            return new CreateModelVersionResponseModel
            {
                VersionId = newVersion.Id,
                ModelId = request.ModelId,
                ModelName = DbContext.Models.FirstOrDefault(x => x.Id == request.ModelId).ModelName,
                StorageCapacity = newVersion.StorageCapacity,
                Price = request.Price,
                StockStatus = request.StockStatus
            };

        }
    }
}
