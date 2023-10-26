using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneSeller_WebAPI.App.Models.GetModel;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.ModelVersions.GetVersion
{
    public class GetVersionCommandHandler : IRequestHandler<GetVersionCommand,GetVersionResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetVersionCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<GetVersionResponseModel> Handle(GetVersionCommand request, CancellationToken cancellationToken)
        {
            var version = DbContext.ModelVersions.Include(x=>x.Model).FirstOrDefault(b => b.Id == request.VersionId);

            if (version == null)
            {
                throw new BadHttpRequestException("version not found");
            }

            return new GetVersionResponseModel
            {
                ID = version.Id,
                ModelName = version.Model.ModelName,
                StorageCapacity =version.StorageCapacity,
                Price = version.Price,
                StockStatus = (Enums.StockStatus)version.StockStatus
            };
        }
    }
}
