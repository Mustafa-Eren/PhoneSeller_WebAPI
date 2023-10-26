using System;
using System.Collections.Generic;

namespace PhoneSeller_WebAPI.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
