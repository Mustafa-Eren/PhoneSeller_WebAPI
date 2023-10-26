using MediatR;
using PhoneSeller_WebAPI.Models;

namespace PhoneSeller_WebAPI.App.Brands.CreateBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandResponseModel>
    {
        public PhoneSellerContext DbContext { get; }
        private readonly IConfiguration configuration;
        public DeleteBrandCommandHandler(PhoneSellerContext _dbContext, IConfiguration _configuration)
        {
            DbContext = _dbContext;
            configuration = _configuration;
        }
        public async Task<DeleteBrandResponseModel> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = DbContext.Brands.FirstOrDefault(b => b.Id == request.BrandId);

            if (brand == null)
            {
                throw new BadHttpRequestException("brand not found");
            }

            DbContext.Brands.Remove(brand);
            await DbContext.SaveChangesAsync();
            return new DeleteBrandResponseModel { IsDelete = true };
        }
    }
}
