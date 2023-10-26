using System;
using System.Collections.Generic;

namespace PhoneSeller_WebAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CreatedBy { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
