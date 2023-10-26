using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.ModelVersions.CreateModelVersion
{
    public class CreateModelVersionCommand :IRequest<CreateModelVersionResponseModel>
    {
        public int ModelId { get; set; }
        [Required]
        public int StorageCapacity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int StockStatus { get; set; }

    }
}
