using MediatR;
using PhoneSeller_WebAPI.App.Brands.CreateBrand;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Models.DeleteModel
{
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeleteModelResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public DeleteModelCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<DeleteModelResponseModel> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var model = DbContext.Models.FirstOrDefault(b => b.Id == request.ModelId);

            if (model == null)
            {
                throw new BadHttpRequestException("model not found");
            }

            DbContext.Models.Remove(model);
            await DbContext.SaveChangesAsync();
            return new DeleteModelResponseModel
            {
                IsDelete = true
            };
        }
    }
}
