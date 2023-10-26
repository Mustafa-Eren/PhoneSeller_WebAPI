using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PhoneSeller_WebAPI.App.ModelVersions.UpdateVersion
{
    public class UpdateVersionCommand : IRequest<UpdateVersionResponseModel>
    {
        public int VersionId { get; set; }
        public int? StorageCapacity { get; set; }
        public int? Price { get; set; }
        public int? StockStatus { get; set; }

    }
}
