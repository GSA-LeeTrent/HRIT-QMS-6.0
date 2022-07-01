using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsStfacqError
    {
        public int QmsStfacqErrorId { get; set; }
        public string QmsKey { get; set; }
        public int DataItemId { get; set; }
        public int ErrorListId { get; set; }
        public string SystemName { get; set; }
        public string ErrorSummary { get; set; }
        public string ErrorDetails { get; set; }
        public string Notes { get; set; }
        public string ShortErrorDescription { get; set; }
        public uint? AssignedToUserId { get; set; }
        public uint? AssignedByUserId { get; set; }
        public uint? AssignedToOrgId { get; set; }
        public uint? CreatedByUserId { get; set; }
        public uint? StatusId { get; set; }
        public string QmsErrorCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AssignedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public sbyte? RowVersion { get; set; }

        public virtual SecUser AssignedByUser { get; set; }
        public virtual SecOrg AssignedToOrg { get; set; }
        public virtual SecUser AssignedToUser { get; set; }
        public virtual SecUser CreatedByUser { get; set; }
        public virtual QmsDataItem DataItem { get; set; }
        public virtual QmsMasterErrorList ErrorList { get; set; }
        public virtual QmsStatus Status { get; set; }
    }
}
