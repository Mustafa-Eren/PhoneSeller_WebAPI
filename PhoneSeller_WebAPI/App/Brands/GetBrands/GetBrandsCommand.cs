using MediatR;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.Brands.GetBrands
{
    public class GetBrandsCommand : IRequest<BaseListResponse<GetBrandsResponseModel>>
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
    }
}
