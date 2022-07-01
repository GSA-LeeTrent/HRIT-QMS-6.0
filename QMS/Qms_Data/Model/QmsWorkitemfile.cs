using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsWorkitemfile
    {
        public int Id { get; set; }
        public uint? UploadedByUserId { get; set; }
        public uint WorkItemId { get; set; }
        public string WorkItemTypeCode { get; set; }
        public string Filepath { get; set; }
        public string Filetype { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime Deletedat { get; set; }

        public virtual SecUser UploadedByUser { get; set; }
        public virtual QmsWorkitemtype WorkItemTypeCodeNavigation { get; set; }
    }
}
