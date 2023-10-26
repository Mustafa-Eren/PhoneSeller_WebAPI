using System;
using System.Collections.Generic;

namespace PhoneSeller_WebAPI.Models
{
    public partial class ModelVersion
    {
        public int Id { get; set; }
        public int? ModelId { get; set; }
        public int? StorageCapacity { get; set; }
        public int? Price { get; set; }
        public int? StockStatus { get; set; }

        public virtual Model? Model { get; set; }
    }
}
