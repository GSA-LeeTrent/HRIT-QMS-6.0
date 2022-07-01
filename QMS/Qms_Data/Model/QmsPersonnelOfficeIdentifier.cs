using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsPersonnelOfficeIdentifier
    {
        public int PoiId { get; set; }
        public string PoiCode { get; set; }
        public string PoiLabel { get; set; }
        public uint OrgId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SecOrg Org { get; set; }
    }
}
