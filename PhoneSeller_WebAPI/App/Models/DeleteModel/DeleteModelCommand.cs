using MediatR;

namespace PhoneSeller_WebAPI.App.Models.DeleteModel
{
    public class DeleteModelCommand :IRequest<DeleteModelResponseModel>
    {
        public int ModelId { get; set; }
    }
}
