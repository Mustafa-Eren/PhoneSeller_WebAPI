using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Brands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreateBrandResponseModel>
    {
        [Required]
        public string? BrandName  { get; set; }
    }
}
