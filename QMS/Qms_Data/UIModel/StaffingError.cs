using QmsCore.Lib;
using QmsCore.Model;
using QmsCore.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QmsCore.UIModel
{
    public class StaffingError
    {
        internal int orgViewerIsFrom;
        public bool IsReadOnly = true;
        public string WorkItemType {get{ return QmsCore.Model.WorkItemTypeEnum.StaffAcquisition; } }
        public int Id {get { return QmsOhrErrorId; } set { QmsOhrErrorId = value; } }
        public List<StaffingErrorComment> Comments { get; set; }
        public List<StaffingErrorHistory> Histories { get; set; }
        public int QmsOhrErrorId { get; set; }
        public string QmsKey { get; set; }
        public int DataItemId { get; set; }
        public int ErrorListId { get; set; }
        public string Notes { get; set; }
        public string SystemName { get; set; }
        public string ErrorSummary { get; set; }
        public string ErrorDetails { get; set; }
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

        public virtual User AssignedByUser { get; set; }
        public virtual Organization AssignedToOrg { get; set; }
        public virtual User AssignedToUser { get; set; }
        public virtual Status Status { get; set; }

        public StaffingError()
        { }

        public StaffingError(QmsStfacqError error)
        {
            setupError(error);
        }

        public StaffingError(QmsStfacqError error, User viewer)
        {
            setupError(error);
            orgViewerIsFrom = viewer.OrgId.Value;
            //setReadOnly();
        }

        internal void loadHistory(IQueryable<QmsWorkitemhistory> histories)
        {
            Histories = new List<StaffingErrorHistory>();
            foreach (var history in histories)
            {
                Histories.Add(new StaffingErrorHistory(history));
            }
        }

        internal void loadComments(IQueryable<QmsWorkitemcomment> comments)
        {
            Comments = new List<StaffingErrorComment>();
            foreach (var item in comments)
            {
                Comments.Add(new StaffingErrorComment(item,false));
            }
        }
        public QmsStfacqError QmsOhrError()
        {
            QmsStfacqError error = new QmsStfacqError();
            error.AssignedAt = this.AssignedAt;
            error.AssignedByUserId = this.AssignedByUserId;
            error.AssignedToOrgId = this.AssignedToOrgId;
            error.AssignedToUserId = this.AssignedToUserId;
            error.CreatedAt = this.CreatedAt;
            error.CreatedByUserId = this.CreatedByUserId;
            error.DataItemId = this.DataItemId;
            error.ErrorListId = this.ErrorListId;
            error.ShortErrorDescription = this.ShortErrorDescription;
            error.DeletedAt = this.DeletedAt;
            error.QmsStfacqErrorId = this.QmsOhrErrorId;
            error.QmsKey = this.QmsKey;
            error.Notes = this.Notes;
            error.ErrorDetails = this.ErrorDetails;
            error.SystemName = this.SystemName;
            error.ErrorSummary = this.ErrorSummary;
            error.QmsErrorCode = this.QmsErrorCode;
            error.ResolvedAt = this.ResolvedAt;
            error.StatusId = this.StatusId;
            error.SubmittedAt = this.SubmittedAt;
            error.UpdatedAt = this.UpdatedAt;
            error.RowVersion = this.RowVersion;
            return error;
        }


        public int? DaysSinceAssigned
        {
            get
            {
                if (this.AssignedAt.HasValue)
                {
                    return DateCalc.DaysBetween(this.AssignedAt.Value, DateTime.Now);
                }
                else
                {
                    return null;
                }

            }
        }

        private void setReadOnly(User user)
        {
            bool keepChecking = true;
            string currentStatus = this.Status.StatusCode;

            //check if it's been closed for more than 30 days
            if (currentStatus == StatusType.CLOSED || currentStatus == StatusType.CLOSED_ACTION_COMPLETED || currentStatus == StatusType.CLOSED_CONVERT_TO_CORR_ACTION)
            {
                int daysOld = DateCalc.DaysBetween(this.ResolvedAt.Value, DateTime.Now);
                if (daysOld >= 30)
                {
                    keepChecking = false;
                    IsReadOnly = true;
                }
            }

            //check if user has read only permissions
            if (keepChecking)
            {
                IsReadOnly = ((UserUtil.UserHasPermission(user, StaffingErrorViewPermissionEnum.VIEW_ALL_STFACQ_ERRORS)) || (UserUtil.UserHasPermission(user, StaffingErrorViewPermissionEnum.VIEW_ALL_ARCHIVE_STFACQ_ERRORS)));
                keepChecking = !IsReadOnly;
            }


            //check for users with editing permissions
            if (keepChecking)
            {
                bool isSCReviewer = UserUtil.UserHasRole(user, ApplicationRoleType.SC_REVIEWER);
                bool isSCSpecialist = UserUtil.UserHasRole(user, ApplicationRoleType.SC_SPECIALIST);
                bool isBRCReviewer = UserUtil.UserHasRole(user, ApplicationRoleType.PPRB_REVIEWER);
                bool isBRCSpecialist = UserUtil.UserHasRole(user, ApplicationRoleType.PPRB_SPECIALIST);
                bool isPPRMReviewer = UserUtil.UserHasRole(user, ApplicationRoleType.PPRM_REVIEWER);
                bool isPPRMSpecialist = UserUtil.UserHasRole(user, ApplicationRoleType.PPRM_SPECIALIST);
                if (isBRCSpecialist || isSCSpecialist || isPPRMSpecialist)
                {
                    if (this.AssignedToUserId == user.UserId)
                    {
                        IsReadOnly = false;  //It's assigned to them
                    }
                    else
                    {
                        IsReadOnly = true;
                    }
                }
                else if (isBRCReviewer || isSCReviewer || isPPRMReviewer)
                {
                    if (this.AssignedToOrgId == user.OrgId.Value)
                    {
                        IsReadOnly = false;  //It's assigned to their org
                    }
                    else
                    {
                        IsReadOnly = true;
                    }
                }
                else
                {
                    IsReadOnly = true;
                }
            }
        }



        public bool IsAssignable
        {
            get
            {
                bool retval = false;
                try
                {
                    uint i = this.StatusId.Value;
                    uint? orgId = this.AssignedToOrgId;
                    int UNASSIGNED = 1;
                    int ASSIGNED = 2;
                    int PENDING_REVIEW = 3;

                    if ((orgId == orgViewerIsFrom) && (i == UNASSIGNED) || (i == PENDING_REVIEW) || (i == ASSIGNED))
                    {
                        retval = true;
                    }

                }
                catch (System.Exception)
                {
                }
                return retval;
            }
        }

        private void setupError(QmsStfacqError error)
        {
            this.AssignedAt = error.AssignedAt;
            this.AssignedByUserId = error.AssignedByUserId;
            if (this.AssignedByUserId.HasValue)
                this.AssignedByUser = new User(error.AssignedByUser, false, false);

            this.AssignedToOrgId = error.AssignedToOrgId;
            if (this.AssignedToOrgId.HasValue)
                this.AssignedToOrg = new Organization(error.AssignedToOrg);

            this.AssignedToUserId = error.AssignedToUserId;
            if (this.AssignedToUserId.HasValue)
                this.AssignedToUser = new User(error.AssignedToUser, false, false);

            this.CreatedAt = error.CreatedAt;
            this.CreatedByUserId = error.CreatedByUserId;
            this.DataItemId = error.DataItemId;
            this.ErrorListId = error.ErrorListId;
            this.ShortErrorDescription = error.ShortErrorDescription;
            this.DeletedAt = error.DeletedAt;
            this.QmsOhrErrorId = error.QmsStfacqErrorId;
            this.QmsKey = error.QmsKey;
            this.ErrorDetails = error.ErrorDetails;
            this.SystemName = error.SystemName;
            this.ErrorSummary = error.ErrorSummary;
            this.QmsErrorCode = error.QmsErrorCode;
            this.ResolvedAt = error.ResolvedAt;
            this.StatusId = error.StatusId;
            this.Status = new Status(error.Status);
            this.SubmittedAt = error.SubmittedAt;
            this.UpdatedAt = error.UpdatedAt;
            this.RowVersion = error.RowVersion;
            this.Notes = error.Notes;
        }

    }//end class
}//end namespace
