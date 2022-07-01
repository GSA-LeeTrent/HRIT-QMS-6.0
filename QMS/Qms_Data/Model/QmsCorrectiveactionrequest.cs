using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsCorrectiveactionrequest
    {
        public QmsCorrectiveactionrequest()
        {
            QmsCorrectiveactionErrortype = new HashSet<QmsCorrectiveactionErrortype>();
            QmsDataerror = new HashSet<QmsDataerror>();
        }

        public int Id { get; set; }
        public int? ActionRequestTypeId { get; set; }
        public string EmplId { get; set; }
        public string NatureOfAction { get; set; }
        public DateTime EffectiveDateOfPar { get; set; }
        public string IsPaymentMismatch { get; set; }
        public DateTime? PareffectiveDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Updatedat { get; set; }
        public DateTime? Resolvedat { get; set; }
        public uint? AssignedByUserId { get; set; }
        public uint? AssignedToUserId { get; set; }
        public uint? AssignedToOrgId { get; set; }
        public DateTime? Assignedat { get; set; }
        public uint? StatusId { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public DateTime? Deletedat { get; set; }
        public uint? CreatedByUserId { get; set; }
        public string Details { get; set; }
        public uint? CreatedAtOrgId { get; set; }
        public sbyte RowVersion { get; set; }

        public virtual QmsCorrectiveactiontype ActionRequestType { get; set; }
        public virtual SecUser AssignedByUser { get; set; }
        public virtual SecOrg AssignedToOrg { get; set; }
        public virtual SecUser AssignedToUser { get; set; }
        public virtual SecOrg CreatedAtOrg { get; set; }
        public virtual SecUser CreatedByUser { get; set; }
        public virtual QmsEmployee Empl { get; set; }
        public virtual QmsNatureofaction NatureOfActionNavigation { get; set; }
        public virtual QmsStatus Status { get; set; }
        public virtual ICollection<QmsCorrectiveactionErrortype> QmsCorrectiveactionErrortype { get; set; }
        public virtual ICollection<QmsDataerror> QmsDataerror { get; set; }
    }
}
