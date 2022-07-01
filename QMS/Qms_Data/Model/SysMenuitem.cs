using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SysMenuitem
    {
        public int MenuitemId { get; set; }
        public int ModuleId { get; set; }
        public string MenuitemCode { get; set; }
        public string MenuitemLabel { get; set; }
        public uint? PermissionId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string QueryString { get; set; }
        public sbyte DisplayOrder { get; set; }
        public string IconOn { get; set; }
        public string IconOff { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SysModule Module { get; set; }
        public virtual SecPermission Permission { get; set; }
    }
}
