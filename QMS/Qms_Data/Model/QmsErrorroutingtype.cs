using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsErrorroutingtype
    {
        public QmsErrorroutingtype()
        {
            QmsMasterErrorList = new HashSet<QmsMasterErrorList>();
        }

        public int ErrorRoutingTypeId { get; set; }
        public string ErrorRoutingTypeCode { get; set; }
        public string ErrorRoutingTypeLabel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<QmsMasterErrorList> QmsMasterErrorList { get; set; }
    }
}
