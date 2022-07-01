using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SecPermission
    {
        public SecPermission()
        {
            SecRolePermission = new HashSet<SecRolePermission>();
        }

        public uint PermissionId { get; set; }
        public string PermissionCode { get; set; }
        public string PermissionLabel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SysMenuitem SysMenuitem { get; set; }
        public virtual ICollection<SecRolePermission> SecRolePermission { get; set; }
    }
}
