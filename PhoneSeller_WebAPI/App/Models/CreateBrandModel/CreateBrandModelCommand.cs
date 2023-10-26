using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Models.CreateBrandModel
{
    public class CreateBrandModelCommand :IRequest<CreateBrandModelResponseModel>
    {
        public int BrandId { get; set; }
        [Required]
        public string ModelName { get; set; }
    }
}
