using PhoneSeller_WebAPI.Enums;

namespace PhoneSeller_WebAPI.App.ModelVersions.GetModelVersions
{
    public class GetModelVersionsResponseModel
    {
        public string? BrandName { get; set; }
        public string? ModelName { get; set; }
        public int? StorageCappacity { get; set; }
        public int? Price  { get; set; }
        public StockStatus StockStatus { get; set; }
    }
}
