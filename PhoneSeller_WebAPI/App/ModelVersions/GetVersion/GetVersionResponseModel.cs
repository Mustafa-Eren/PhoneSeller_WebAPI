using PhoneSeller_WebAPI.Enums;

namespace PhoneSeller_WebAPI.App.ModelVersions.GetVersion
{
    public class GetVersionResponseModel
    {
        public int ID { get; set; }

        public string? ModelName { get; set; }
        public int? StorageCapacity { get; set; }
        public int? Price { get; set; }
        public StockStatus StockStatus { get; set; }
    }
}
