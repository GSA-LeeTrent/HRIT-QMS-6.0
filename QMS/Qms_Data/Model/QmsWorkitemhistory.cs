using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsWorkitemhistory
    {
        public int Id { get; set; }
        public int WorkItemId { get; set; }
        public string WorkItemTypeCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public uint? ActionTakenByUserId { get; set; }
        public uint? PreviousStatusId { get; set; }
        public uint? PreviousAssignedToOrgId { get; set; }
        public uint? PreviousAssignedtoUserId { get; set; }
        public uint? PreviousAssignedByUserId { get; set; }
        public string ActionDescription { get; set; }

        public virtual SecUser ActionTakenByUser { get; set; }
        public virtual SecUser PreviousAssignedByUser { get; set; }
        public virtual SecOrg PreviousAssignedToOrg { get; set; }
        public virtual SecUser PreviousAssignedtoUser { get; set; }
        public virtual QmsStatus PreviousStatus { get; set; }
        public virtual QmsWorkitemtype WorkItemTypeCodeNavigation { get; set; }
    }
}
