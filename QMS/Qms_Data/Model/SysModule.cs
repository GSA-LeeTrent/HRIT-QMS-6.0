using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SysModule
    {
        public SysModule()
        {
            SysMenuitem = new HashSet<SysMenuitem>();
            SysModuleRole = new HashSet<SysModuleRole>();
        }

        public int ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleLabel { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string QueryString { get; set; }
        public sbyte DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<SysMenuitem> SysMenuitem { get; set; }
        public virtual ICollection<SysModuleRole> SysModuleRole { get; set; }
    }
}
