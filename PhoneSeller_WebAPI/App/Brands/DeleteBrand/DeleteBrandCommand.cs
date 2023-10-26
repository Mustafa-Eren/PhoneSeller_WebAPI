using MediatR;

namespace PhoneSeller_WebAPI.App.Brands.CreateBrand
{
    public class DeleteBrandCommand : IRequest<DeleteBrandResponseModel>
    {
        public int BrandId { get; set; }
    }
}
