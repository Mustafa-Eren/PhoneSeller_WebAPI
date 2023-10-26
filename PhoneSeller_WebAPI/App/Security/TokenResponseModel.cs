namespace PhoneSeller_WebAPI.App.Security
{
    public class TokenResponseModel
    {
        public string? Token { get; set; }
        public int ID { get; set; }

        public string? Permission { get; set; }
    }
}
