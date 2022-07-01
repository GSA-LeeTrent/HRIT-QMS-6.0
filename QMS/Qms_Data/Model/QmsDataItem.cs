using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsDataItem
    {
        public QmsDataItem()
        {
            QmsMasterErrorList = new HashSet<QmsMasterErrorList>();
            QmsStfacqError = new HashSet<QmsStfacqError>();
        }

        public int DataItemId { get; set; }
        public string SystemName { get; set; }
        public string DataItemName { get; set; }
        public string DataItemCategory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<QmsMasterErrorList> QmsMasterErrorList { get; set; }
        public virtual ICollection<QmsStfacqError> QmsStfacqError { get; set; }
    }
}
