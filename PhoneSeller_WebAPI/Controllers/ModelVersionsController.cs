using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneSeller_WebAPI.App.ModelVersions.CreateModelVersion;
using PhoneSeller_WebAPI.App.ModelVersions.DeleteVersion;
using PhoneSeller_WebAPI.App.ModelVersions.GetModelVersions;
using PhoneSeller_WebAPI.App.ModelVersions.GetVersion;
using PhoneSeller_WebAPI.App.ModelVersions.UpdateVersion;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class ModelVersionsController : BaseController
    {
        [HttpGet("model/{modelId}/versions")]
        public async Task<BaseListResponse<GetModelVersionsResponseModel>> GetModelVersionsList([FromQuery] GetModelVersionsCommand command, [FromRoute] int modelId)
        {
            command.ModelId = modelId;

            return await Mediator.Send(command);
        }

        [HttpGet("version/{versionId}")]
        public async Task<GetVersionResponseModel> GetVersion([FromQuery] GetVersionCommand command, [FromRoute] int versionId)
        {
            command.VersionId = versionId;

            return await Mediator.Send(command);
        }

        [HttpPost("model/{modelId}/versions")]
        public async Task<CreateModelVersionResponseModel> CreateModelVersion([FromQuery] CreateModelVersionCommand command, [FromRoute] int modelId)
        {
            command.ModelId = modelId;

            return await Mediator.Send(command);
        }

        [HttpPut("version/{versionId}")]
        public async Task<UpdateVersionResponseModel> UpdateVersion([FromQuery] UpdateVersionCommand command, [FromRoute] int versionId)
        {
            command.VersionId = versionId;

            return await Mediator.Send(command);
        }

        [HttpDelete("version/{versionId}")]
        public async Task<DeleteVersionResponseModel> DeleteVersion([FromQuery] DeleteVersionCommand command, [FromRoute] int versionId)
        {
            command.VersionId = versionId;

            return await Mediator.Send(command);
        }
    }
}
