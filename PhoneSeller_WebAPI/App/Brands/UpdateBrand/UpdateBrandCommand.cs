using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Brands.CreateBrand
{
    public class UpdateBrandCommand : IRequest<UpdateBrandResponseModel>
    {
        public int BrandId { get; set; }
        [Required]
        public string? BrandName { get; set; }
    }
}
