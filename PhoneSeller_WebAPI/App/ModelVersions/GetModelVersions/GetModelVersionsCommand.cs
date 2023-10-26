using MediatR;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.App.ModelVersions.GetModelVersions
{
    public class GetModelVersionsCommand : IRequest<BaseListResponse<GetModelVersionsResponseModel>>
    {
        public int? ModelId { get; set; }

    }
}
