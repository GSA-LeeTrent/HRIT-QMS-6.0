using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsStatusTrans
    {
        public QmsStatusTrans()
        {
            QmsOrgStatusTrans = new HashSet<QmsOrgStatusTrans>();
        }

        public uint StatusTransId { get; set; }
        public uint FromStatusId { get; set; }
        public uint ToStatusId { get; set; }
        public string StatusTransCode { get; set; }
        public string StatusTransLabel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual QmsStatus FromStatus { get; set; }
        public virtual QmsStatus ToStatus { get; set; }
        public virtual ICollection<QmsOrgStatusTrans> QmsOrgStatusTrans { get; set; }
    }
}
