using MediatR;
using PhoneSeller_WebAPI.App.Security;

namespace PhoneSeller_WebAPI.Security
{
    public class TokenCommand : IRequest<TokenResponseModel>
    {
        //public string AccessToken { get; set; }
        ////public string RefreshToken { get; set; }
        //public int ID { get; set; } 
        //public string Permission  { get; set; }
        //public DateTime Expiration { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
