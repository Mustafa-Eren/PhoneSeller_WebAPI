using System;
using System.Collections.Generic;

namespace PhoneSeller_WebAPI.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalPrice { get; set; }
        public int? OrderStatus { get; set; }
        public string? OrderDescription { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
