namespace PhoneSeller_WebAPI.App.ModelVersions.CreateModelVersion
{
    public class CreateModelVersionResponseModel
    {
        public int VersionId { get; set; }
        public int ModelId { get; set; }
        public string? ModelName { get; set; }
        public int? StorageCapacity { get; set; }
        public int? Price { get; set; }
        public int? StockStatus { get; set; }
    }
}
