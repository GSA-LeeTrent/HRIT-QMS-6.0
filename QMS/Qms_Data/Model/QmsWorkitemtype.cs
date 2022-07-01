using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsWorkitemtype
    {
        public QmsWorkitemtype()
        {
            NtfNotification = new HashSet<NtfNotification>();
            QmsOrgStatusTrans = new HashSet<QmsOrgStatusTrans>();
            QmsWorkitemcomment = new HashSet<QmsWorkitemcomment>();
            QmsWorkitemfile = new HashSet<QmsWorkitemfile>();
            QmsWorkitemhistory = new HashSet<QmsWorkitemhistory>();
            QmsWorkitemviewlog = new HashSet<QmsWorkitemviewlog>();
        }

        public int WorkItemTypeId { get; set; }
        public string WorkItemTypeCode { get; set; }
        public string WorkItemTypeLabel { get; set; }
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<NtfNotification> NtfNotification { get; set; }
        public virtual ICollection<QmsOrgStatusTrans> QmsOrgStatusTrans { get; set; }
        public virtual ICollection<QmsWorkitemcomment> QmsWorkitemcomment { get; set; }
        public virtual ICollection<QmsWorkitemfile> QmsWorkitemfile { get; set; }
        public virtual ICollection<QmsWorkitemhistory> QmsWorkitemhistory { get; set; }
        public virtual ICollection<QmsWorkitemviewlog> QmsWorkitemviewlog { get; set; }
    }
}
