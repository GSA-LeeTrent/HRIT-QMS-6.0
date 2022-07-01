using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsOrgStatusTrans
    {
        public uint OrgStatusTransId { get; set; }
        public uint StatusTransId { get; set; }
        public uint FromOrgId { get; set; }
        public uint ToOrgtypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string WorkItemTypeCode { get; set; }

        public virtual QmsStatusTrans StatusTrans { get; set; }
        public virtual QmsOrgtype ToOrgtype { get; set; }
        public virtual QmsWorkitemtype WorkItemTypeCodeNavigation { get; set; }
    }
}
