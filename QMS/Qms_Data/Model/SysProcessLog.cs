using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SysProcessLog
    {
        public int SysId { get; set; }
        public int? ProcessId { get; set; }
        public DateTime? ProcessDate { get; set; }
        public DateTime? ProcessStart { get; set; }
        public DateTime? ProcessEnd { get; set; }
        public string ProcessSource { get; set; }
        public int? ProcessInputCount { get; set; }
        public int? ProcessInsertCount { get; set; }
        public int? ProcessUpdateCount { get; set; }
        public int? ProcessDeleteCount { get; set; }
        public string StagingCompleted { get; set; }
        public string MigrationCompleted { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
