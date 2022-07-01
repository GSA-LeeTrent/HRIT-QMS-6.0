using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsErrorStat
    {
        public int QmsErrorStat1 { get; set; }
        public string Poid { get; set; }
        public string ErrorCode { get; set; }
        public DateTime SnapshotDate { get; set; }
        public int ErrorCount { get; set; }
    }
}
