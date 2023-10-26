using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneSeller_WebAPI.App.Models.CreateBrandModel;
using PhoneSeller_WebAPI.App.Models.DeleteModel;
using PhoneSeller_WebAPI.App.Models.GetBrandModels;
using PhoneSeller_WebAPI.App.Models.GetModel;
using PhoneSeller_WebAPI.App.Models.UpdateModel;
using PhoneSeller_WebAPI.Models;
using PhoneSeller_WebAPI.Response;

namespace PhoneSeller_WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class ModelsController : BaseController
    {
        [HttpGet("brand/{brandId}/models")]
        public async Task<BaseListResponse<GetBrandModelsResponseModel>> GetBrandModelsList([FromQuery] GetBrandModelsCommand command, [FromRoute] int brandId)
        {
            command.BrandId = brandId;

            return await Mediator.Send(command);
        }

        [HttpGet("model/{modelId}")]
        public async Task<GetModelResponseModel> GetModel([FromQuery] GetModelCommand command, [FromRoute] int modelId)
        {
            command.ModelId = modelId;

            return await Mediator.Send(command);
        }

        [HttpPost("brand/{brandId}/models")]
        public async Task<CreateBrandModelResponseModel> CreateBrandModel([FromQuery] CreateBrandModelCommand command, [FromRoute] int brandId)
        {
            command.BrandId = brandId;

            return await Mediator.Send(command);
        }

        [HttpPut("model/{modelId}")]
        public async Task<UpdateModelResponseModel> UpdateModel([FromQuery] UpdateModelCommand command, [FromRoute] int modelId)
        {
            command.ModelId = modelId;

            return await Mediator.Send(command);
        }

        [HttpDelete("model/{modelId}")]
        public async Task<DeleteModelResponseModel> DeleteModel([FromQuery] DeleteModelCommand command, [FromRoute] int modelId)
        {
            command.ModelId = modelId;

            return await Mediator.Send(command);
        }
    }
}
