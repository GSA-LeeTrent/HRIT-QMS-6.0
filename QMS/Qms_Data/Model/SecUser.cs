using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SecUser
    {
        public SecUser()
        {
            EpcEmployeepositioncategory = new HashSet<EpcEmployeepositioncategory>();
            InverseManager = new HashSet<SecUser>();
            NtfNotification = new HashSet<NtfNotification>();
            NtfNotificationuserpreference = new HashSet<NtfNotificationuserpreference>();
            QmsCorrectiveactionrequestAssignedByUser = new HashSet<QmsCorrectiveactionrequest>();
            QmsCorrectiveactionrequestAssignedToUser = new HashSet<QmsCorrectiveactionrequest>();
            QmsCorrectiveactionrequestCreatedByUser = new HashSet<QmsCorrectiveactionrequest>();
            QmsDataerrorAssignedByUser = new HashSet<QmsDataerror>();
            QmsDataerrorAssignedToUser = new HashSet<QmsDataerror>();
            QmsDataerrorCreatedByUser = new HashSet<QmsDataerror>();
            QmsStfacqErrorAssignedByUser = new HashSet<QmsStfacqError>();
            QmsStfacqErrorAssignedToUser = new HashSet<QmsStfacqError>();
            QmsStfacqErrorCreatedByUser = new HashSet<QmsStfacqError>();
            QmsWorkitemcomment = new HashSet<QmsWorkitemcomment>();
            QmsWorkitemfile = new HashSet<QmsWorkitemfile>();
            QmsWorkitemhistoryActionTakenByUser = new HashSet<QmsWorkitemhistory>();
            QmsWorkitemhistoryPreviousAssignedByUser = new HashSet<QmsWorkitemhistory>();
            QmsWorkitemhistoryPreviousAssignedtoUser = new HashSet<QmsWorkitemhistory>();
            SecSecuritylog = new HashSet<SecSecuritylog>();
            SecUserRole = new HashSet<SecUserRole>();
        }

        public uint UserId { get; set; }
        public uint? ManagerId { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public uint? OrgId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual SecUser Manager { get; set; }
        public virtual SecOrg Org { get; set; }
        public virtual ICollection<EpcEmployeepositioncategory> EpcEmployeepositioncategory { get; set; }
        public virtual ICollection<SecUser> InverseManager { get; set; }
        public virtual ICollection<NtfNotification> NtfNotification { get; set; }
        public virtual ICollection<NtfNotificationuserpreference> NtfNotificationuserpreference { get; set; }
        public virtual ICollection<QmsCorrectiveactionrequest> QmsCorrectiveactionrequestAssignedByUser { get; set; }
        public virtual ICollection<QmsCorrectiveactionrequest> QmsCorrectiveactionrequestAssignedToUser { get; set; }
        public virtual ICollection<QmsCorrectiveactionrequest> QmsCorrectiveactionrequestCreatedByUser { get; set; }
        public virtual ICollection<QmsDataerror> QmsDataerrorAssignedByUser { get; set; }
        public virtual ICollection<QmsDataerror> QmsDataerrorAssignedToUser { get; set; }
        public virtual ICollection<QmsDataerror> QmsDataerrorCreatedByUser { get; set; }
        public virtual ICollection<QmsStfacqError> QmsStfacqErrorAssignedByUser { get; set; }
        public virtual ICollection<QmsStfacqError> QmsStfacqErrorAssignedToUser { get; set; }
        public virtual ICollection<QmsStfacqError> QmsStfacqErrorCreatedByUser { get; set; }
        public virtual ICollection<QmsWorkitemcomment> QmsWorkitemcomment { get; set; }
        public virtual ICollection<QmsWorkitemfile> QmsWorkitemfile { get; set; }
        public virtual ICollection<QmsWorkitemhistory> QmsWorkitemhistoryActionTakenByUser { get; set; }
        public virtual ICollection<QmsWorkitemhistory> QmsWorkitemhistoryPreviousAssignedByUser { get; set; }
        public virtual ICollection<QmsWorkitemhistory> QmsWorkitemhistoryPreviousAssignedtoUser { get; set; }
        public virtual ICollection<SecSecuritylog> SecSecuritylog { get; set; }
        public virtual ICollection<SecUserRole> SecUserRole { get; set; }
    }
}
