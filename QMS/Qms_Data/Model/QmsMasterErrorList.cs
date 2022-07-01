using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsMasterErrorList
    {
        public QmsMasterErrorList()
        {
            QmsDataerror = new HashSet<QmsDataerror>();
            QmsStfacqError = new HashSet<QmsStfacqError>();
        }

        public int ErrorListId { get; set; }
        public int DataItemId { get; set; }
        public string QmsErrorCode { get; set; }
        public string HrdwDataLoadEnabled { get; set; }
        public string QmsDataLoadEnabled { get; set; }
        public int ErrorRoutingTypeId { get; set; }
        public int DataRoutingTypeId { get; set; }
        public string ErrorMessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual QmsDataItem DataItem { get; set; }
        public virtual QmsDataerrortype DataRoutingType { get; set; }
        public virtual QmsErrorroutingtype ErrorRoutingType { get; set; }
        public virtual ICollection<QmsDataerror> QmsDataerror { get; set; }
        public virtual ICollection<QmsStfacqError> QmsStfacqError { get; set; }
    }
}
