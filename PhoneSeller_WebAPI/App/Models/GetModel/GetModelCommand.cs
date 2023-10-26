using MediatR;

namespace PhoneSeller_WebAPI.App.Models.GetModel
{
    public class GetModelCommand :IRequest<GetModelResponseModel>
    {
        public int ModelId { get; set; }
    }
}
