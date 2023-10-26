using MediatR;

namespace PhoneSeller_WebAPI.App.ModelVersions.GetVersion
{
    public class GetVersionCommand : IRequest<GetVersionResponseModel>
    {
        public int VersionId { get; set; }
    }
}
