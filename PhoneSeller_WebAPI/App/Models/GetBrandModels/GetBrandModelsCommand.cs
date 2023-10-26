using MediatR;
using PhoneSeller_WebAPI.Response;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.Models.GetBrandModels
{
    public class GetBrandModelsCommand : IRequest<BaseListResponse<GetBrandModelsResponseModel>>
    {
        public int BrandId { get; set; }
    }
}
