using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SecSecuritylogtype
    {
        public SecSecuritylogtype()
        {
            SecSecuritylog = new HashSet<SecSecuritylog>();
        }

        public int SecurityLogTypeId { get; set; }
        public string SecurityLogTypeCode { get; set; }
        public string SecurityLogTypeLabel { get; set; }
        public string SecurityLogTemplate { get; set; }
        public int? SecurityItemTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SecSecurityitemtype SecurityItemType { get; set; }
        public virtual ICollection<SecSecuritylog> SecSecuritylog { get; set; }
    }
}
