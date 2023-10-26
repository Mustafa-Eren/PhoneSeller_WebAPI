namespace PhoneSeller_WebAPI.App.Customers.CreateCustomer
{
    public class CreateCustomerResponseModel
    {
        public int ID { get; set; }

        public string? CustomerName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? Email { get; set; }
    }
}
