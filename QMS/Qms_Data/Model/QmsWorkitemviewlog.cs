using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsWorkitemviewlog
    {
        public int Id { get; set; }
        public DateTime Createdat { get; set; }
        public uint? Workitemid { get; set; }
        public string WorkItemTypeCode { get; set; }
        public int Userid { get; set; }

        public virtual QmsWorkitemtype WorkItemTypeCodeNavigation { get; set; }
    }
}
