using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SecSecurityitemtype
    {
        public SecSecurityitemtype()
        {
            SecSecuritylogtype = new HashSet<SecSecuritylogtype>();
        }

        public int SecurityItemTypeId { get; set; }
        public string SecurityItemTypeCode { get; set; }
        public string SecurityItemTypeLabel { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<SecSecuritylogtype> SecSecuritylogtype { get; set; }
    }
}
