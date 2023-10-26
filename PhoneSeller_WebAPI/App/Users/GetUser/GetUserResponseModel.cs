namespace PhoneSeller_WebAPI.App.Users.GetUser
{
    public class GetUserResponseModel
    {
        public int ID { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }

        public string? Permission { get; set; }
    }
}
