using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SecOrg
    {
        public SecOrg()
        {
            InverseParentOrg = new HashSet<SecOrg>();
            QmsCorrectiveactionrequestAssignedToOrg = new HashSet<QmsCorrectiveactionrequest>();
            QmsCorrectiveactionrequestCreatedAtOrg = new HashSet<QmsCorrectiveactionrequest>();
            QmsDataerrorAssignedToOrg = new HashSet<QmsDataerror>();
            QmsDataerrorCreatedByOrg = new HashSet<QmsDataerror>();
            QmsPersonnelOfficeIdentifier = new HashSet<QmsPersonnelOfficeIdentifier>();
            QmsStfacqError = new HashSet<QmsStfacqError>();
            QmsWorkitemhistory = new HashSet<QmsWorkitemhistory>();
            SecUser = new HashSet<SecUser>();
        }

        public uint OrgId { get; set; }
        public uint? ParentOrgId { get; set; }
        public string OrgCode { get; set; }
        public string OrgLabel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public uint? OrgtypeId { get; set; }

        public virtual SecOrg ParentOrg { get; set; }
        public virtual ICollection<SecOrg> InverseParentOrg { get; set; }
        public virtual ICollection<QmsCorrectiveactionrequest> QmsCorrectiveactionrequestAssignedToOrg { get; set; }
        public virtual ICollection<QmsCorrectiveactionrequest> QmsCorrectiveactionrequestCreatedAtOrg { get; set; }
        public virtual ICollection<QmsDataerror> QmsDataerrorAssignedToOrg { get; set; }
        public virtual ICollection<QmsDataerror> QmsDataerrorCreatedByOrg { get; set; }
        public virtual ICollection<QmsPersonnelOfficeIdentifier> QmsPersonnelOfficeIdentifier { get; set; }
        public virtual ICollection<QmsStfacqError> QmsStfacqError { get; set; }
        public virtual ICollection<QmsWorkitemhistory> QmsWorkitemhistory { get; set; }
        public virtual ICollection<SecUser> SecUser { get; set; }
    }
}
