using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class NtfEmaillog
    {
        public int EmailLogId { get; set; }
        public string SentDate { get; set; }
        public int SentAmount { get; set; }
    }
}
