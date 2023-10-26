using System;
using System.Collections.Generic;

namespace PhoneSeller_WebAPI.Models
{
    public partial class Model
    {
        public Model()
        {
            ModelVersions = new HashSet<ModelVersion>();
        }

        public int Id { get; set; }
        public int? BrandId { get; set; }
        public string? ModelName { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<ModelVersion> ModelVersions { get; set; }
    }
}
