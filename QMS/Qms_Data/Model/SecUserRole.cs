using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SecUserRole
    {
        public uint UserOrgRoleId { get; set; }
        public uint UserId { get; set; }
        public uint RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SecRole Role { get; set; }
        public virtual SecUser User { get; set; }
    }
}
