using MediatR;
using PhoneSeller_WebAPI.App.Brands.GetBrand;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Models.GetModel
{
    public class GetModelCommandHandler :IRequestHandler<GetModelCommand,GetModelResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public GetModelCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<GetModelResponseModel> Handle(GetModelCommand request, CancellationToken cancellationToken)
        {
            var model = DbContext.Models.FirstOrDefault(b => b.Id == request.ModelId);

            if (model == null)
            {
                throw new BadHttpRequestException("model not found");
            }

            return new GetModelResponseModel
            {
                ID = model.Id,
                ModelName = model.ModelName
            };
        }
    }
}
