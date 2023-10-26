﻿using System;
using System.Collections.Generic;

namespace PhoneSeller_WebAPI.Models
{
    public partial class User
    {
        public User()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
