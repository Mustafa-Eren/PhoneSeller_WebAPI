using MediatR;

namespace PhoneSeller_WebAPI.App.Users.GetUser
{
    public class GetUserCommand :IRequest<GetUserResponseModel>
    {
    }
}
