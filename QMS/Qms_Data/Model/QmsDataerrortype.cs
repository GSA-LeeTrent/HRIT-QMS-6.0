using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsDataerrortype
    {
        public QmsDataerrortype()
        {
            QmsMasterErrorList = new HashSet<QmsMasterErrorList>();
        }

        public int DataRoutingTypeId { get; set; }
        public string DataRoutingTypeCode { get; set; }
        public string DataRoutingTypeLabel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<QmsMasterErrorList> QmsMasterErrorList { get; set; }
    }
}
