using MediatR;
using PhoneSeller_WebAPI.App.Brands.CreateBrand;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Models.UpdateModel
{
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand,UpdateModelResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public UpdateModelCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<UpdateModelResponseModel> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var model = DbContext.Models.FirstOrDefault(b => b.Id == request.ModelId);

            if (model == null)
            {
                throw new BadHttpRequestException("model not found");
            }

            model.ModelName = request.ModelName;
            DbContext.Models.Update(model);
            await DbContext.SaveChangesAsync();

            return new UpdateModelResponseModel { IsSuccess = true };
        }
    }
}
