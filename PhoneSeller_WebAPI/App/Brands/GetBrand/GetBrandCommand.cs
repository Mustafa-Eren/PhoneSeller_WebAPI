using MediatR;
using PhoneSeller_WebAPI.App.Brands.GetBrand;

namespace PhoneSeller_WebAPI.App.Brands.GetBrand
{
    public class GetBrandCommand: IRequest<GetBrandResponseModel>
    {
        public int BrandId { get; set; }

    }
}
