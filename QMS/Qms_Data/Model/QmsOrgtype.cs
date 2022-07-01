using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsOrgtype
    {
        public QmsOrgtype()
        {
            QmsOrgStatusTrans = new HashSet<QmsOrgStatusTrans>();
        }

        public uint OrgtypeId { get; set; }
        public string OrgtypeLabel { get; set; }
        public string OrgtypeCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<QmsOrgStatusTrans> QmsOrgStatusTrans { get; set; }
    }
}
