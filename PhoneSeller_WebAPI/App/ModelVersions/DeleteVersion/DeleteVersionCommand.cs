using MediatR;

namespace PhoneSeller_WebAPI.App.ModelVersions.DeleteVersion
{
    public class DeleteVersionCommand : IRequest<DeleteVersionResponseModel>
    {
        public int VersionId { get; set; }

    }
}
