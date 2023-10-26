using MediatR;
using PhoneSeller_WebAPI.App.Models.DeleteModel;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.ModelVersions.DeleteVersion
{
    public class DeleteVersionCommandHandler : IRequestHandler<DeleteVersionCommand,DeleteVersionResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public DeleteVersionCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<DeleteVersionResponseModel> Handle(DeleteVersionCommand request, CancellationToken cancellationToken)
        {
            var version = DbContext.ModelVersions.FirstOrDefault(b => b.Id == request.VersionId);

            if (version == null)
            {
                throw new BadHttpRequestException("version not found");
            }

            DbContext.ModelVersions.Remove(version);
            await DbContext.SaveChangesAsync();
            return new DeleteVersionResponseModel
            {
                IsDelete = true
            };
        }
    }
}
