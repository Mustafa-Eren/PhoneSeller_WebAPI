namespace PhoneSeller_WebAPI.App.Users.CreateUser
{
    public class CreateUserResponseModel
    {
        public int ID { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Permission { get; set; }
    }
}
