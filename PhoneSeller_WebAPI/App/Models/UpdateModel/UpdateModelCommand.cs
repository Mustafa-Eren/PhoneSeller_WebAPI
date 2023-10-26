using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Models.UpdateModel
{
    public class UpdateModelCommand :IRequest<UpdateModelResponseModel>
    {
        public int ModelId { get; set; }
        [Required]
        public string? ModelName { get; set; }
    }
}
