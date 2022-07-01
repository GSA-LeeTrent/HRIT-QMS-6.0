using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SecSecuritylog
    {
        public int SecurityLogId { get; set; }
        public int SecurityLogTypeId { get; set; }
        public uint ActionTakenByUserId { get; set; }
        public int ActiontakenOnItemId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual SecUser ActionTakenByUser { get; set; }
        public virtual SecSecuritylogtype SecurityLogType { get; set; }
    }
}
