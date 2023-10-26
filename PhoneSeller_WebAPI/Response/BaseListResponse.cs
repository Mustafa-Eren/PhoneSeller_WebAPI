namespace PhoneSeller_WebAPI.Response
{
    public class BaseListResponse<T>
    {
        public List<T> Items { get; set; }

        public int Total { get; set; }
    }
}
