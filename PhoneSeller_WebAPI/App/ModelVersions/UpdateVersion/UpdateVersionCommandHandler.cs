using MediatR;
using PhoneSeller_WebAPI.App.Models.UpdateModel;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.ModelVersions.UpdateVersion
{
    public class UpdateVersionCommandHandler : IRequestHandler<UpdateVersionCommand, UpdateVersionResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public UpdateVersionCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<UpdateVersionResponseModel> Handle(UpdateVersionCommand request, CancellationToken cancellationToken)
        {
            var version = DbContext.ModelVersions.FirstOrDefault(b => b.Id == request.VersionId);

            if (version == null)
            {
                throw new BadHttpRequestException("version not found");
            }
            _ = request.StorageCapacity == null ? version.StorageCapacity = version.StorageCapacity : version.StorageCapacity = request.StorageCapacity;
            _ = request.Price == null ? version.Price = version.Price : version.Price = request.Price;
            _ = request.StockStatus == null ? version.StockStatus = version.StockStatus : version.StockStatus = request.StockStatus;
            DbContext.ModelVersions.Update(version);
            await DbContext.SaveChangesAsync();

            return new UpdateVersionResponseModel { IsSuccess = true };
        }
    }
}
