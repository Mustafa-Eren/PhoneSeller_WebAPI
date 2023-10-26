using System;
using System.Collections.Generic;

namespace PhoneSeller_WebAPI.Models
{
    public partial class Permission
    {
        public Permission()
        {
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string? PermissionName { get; set; }

        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
