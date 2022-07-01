using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SysReport
    {
        public uint ReportId { get; set; }
        public string ViewName { get; set; }
        public string ReportDescription { get; set; }
        public string IsActive { get; set; }
    }
}
