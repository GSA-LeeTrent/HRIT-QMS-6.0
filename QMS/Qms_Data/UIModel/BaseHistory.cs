using System;
using System.Collections.Generic;
using System.Text;

namespace QmsCore.UIModel
{
    public class BaseHistory : IComparable<BaseHistory>
    {
        public int Id { get; set; }
        public int WorkItemId { get; set; }
        public virtual string WorkItemType { get; }
        public DateTime? CreatedAt { get; set; }

        public string ActionDescription { get; set; }
        public int? ActionTakenByUserId { get; set; }
        public int? PreviousStatusId { get; set; }
        public int? PreviousAssignedToOrgId { get; set; }
        public int? PreviousAssignedtoUserId { get; set; }
        public int? PreviousAssignedByUserId { get; set; }

        public virtual User ActionTakenByUser { get; set; }
        public virtual User PreviousAssignedByUser { get; set; }
        public virtual Organization PreviousAssignedToOrg { get; set; }
        public virtual User PreviousAssignedtoUser { get; set; }
        public virtual Status PreviousStatus { get; set; }
        
        internal bool loadUserSecurity = false;
        internal bool loadUserOrganizationInfo = false;

        public BaseHistory(QmsCore.Model.QmsWorkitemhistory history)
        {
            this.Id = history.Id;
            this.ActionDescription = history.ActionDescription;
            this.WorkItemId = history.WorkItemId;
            this.WorkItemType = history.WorkItemTypeCodeNavigation.WorkItemTypeCode;
            this.CreatedAt = history.CreatedAt;
            this.ActionTakenByUserId = (int?)history.ActionTakenByUserId;
            this.PreviousStatusId = (int?)history.PreviousStatusId;
            this.PreviousAssignedToOrgId = (int?)history.PreviousAssignedToOrgId;
            this.PreviousAssignedtoUserId = (int?)history.PreviousAssignedtoUserId;
            this.PreviousAssignedByUserId = (int?)history.PreviousAssignedByUserId;

            if (this.PreviousStatusId.HasValue)
            {
                this.PreviousStatus = new Status(history.PreviousStatus);
            }
            else
            {
                this.PreviousStatus = new Status() { StatusId = 0, StatusCode = "DRAFT", StatusLabel = "Draft" };
            }

            if (this.ActionTakenByUserId.HasValue)
            {
                this.ActionTakenByUser = new User(history.ActionTakenByUser, loadUserSecurity, loadUserOrganizationInfo);
            }
            else
            {
                this.ActionTakenByUser = new User();
            }


            if (this.PreviousAssignedToOrgId.HasValue)
            {
                this.PreviousAssignedToOrg = new Organization(history.PreviousAssignedToOrg);
            }
            else
            {
                this.PreviousAssignedToOrg = new Organization();
            }

            if (this.PreviousAssignedtoUserId.HasValue)
            {
                this.PreviousAssignedtoUser = new User(history.PreviousAssignedtoUser, loadUserSecurity, loadUserOrganizationInfo);
            }
            else
            {
                this.PreviousAssignedtoUser = new User();
            }

            if (this.PreviousAssignedByUserId.HasValue)
            {
                this.PreviousAssignedByUser = new User(history.PreviousAssignedByUser, loadUserSecurity, loadUserOrganizationInfo);
            }
            else
            {
                this.PreviousAssignedByUser = new User();
            }
        }

        int IComparable<BaseHistory>.CompareTo(BaseHistory other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
