using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SecRolePermission
    {
        public uint RolePermissionId { get; set; }
        public uint RoleId { get; set; }
        public uint PermissionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SecPermission Permission { get; set; }
        public virtual SecRole Role { get; set; }
    }
}
