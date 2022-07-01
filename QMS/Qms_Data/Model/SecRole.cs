using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SecRole
    {
        public SecRole()
        {
            SecRolePermission = new HashSet<SecRolePermission>();
            SecUserRole = new HashSet<SecUserRole>();
            SysModuleRole = new HashSet<SysModuleRole>();
        }

        public uint RoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleLabel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<SecRolePermission> SecRolePermission { get; set; }
        public virtual ICollection<SecUserRole> SecUserRole { get; set; }
        public virtual ICollection<SysModuleRole> SysModuleRole { get; set; }
    }
}
