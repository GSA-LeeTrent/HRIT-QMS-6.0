using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SaStaffacquisitionlistitem
    {
        public int QmsStfacqErrorId { get; set; }
        public string QmsKey { get; set; }
        public string SystemName { get; set; }
        public string ErrorSummary { get; set; }
        public string ErrorDetails { get; set; }
        public string Notes { get; set; }
        public string ShortErrorDescription { get; set; }
        public uint? AssignedToUserId { get; set; }
        public string AssignedToUserName { get; set; }
        public uint? AssignedByUserId { get; set; }
        public string AssignedByUserName { get; set; }
        public uint? AssignedToOrgId { get; set; }
        public string AssignedToOrgName { get; set; }
        public uint? StatusId { get; set; }
        public string StatusDescription { get; set; }
        public string QmsErrorCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AssignedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public sbyte? RowVersion { get; set; }
    }
}
