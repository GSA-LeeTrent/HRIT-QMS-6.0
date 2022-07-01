using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QmsCore.UIModel;
namespace QMS.ViewModels
{
    public class StaffingErrorViewModel
    {
        internal int orgViewerIsFrom;
        public bool IsReadOnly = true;
        public string WorkItemType { get { return QmsCore.Model.WorkItemTypeEnum.EHRI; } }
        public int Id { get { return QmsOhrErrorId; } set { QmsOhrErrorId = value; } }
        public List<StaffingErrorComment> Comments { get; set; }
        public List<StaffingErrorHistory> Histories { get; set; }
        public int QmsOhrErrorId { get; set; }
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
        public string UseCase { get; set; }
        public virtual User AssignedByUser { get; set; }
        public virtual Organization AssignedToOrg { get; set; }
        public virtual User AssignedToUser { get; set; }
        public virtual Status Status { get; set; }

        public string Comment { get; set; } //used for the comment form on the edit page
        public int AuthorId { get; set; } //used for the comment form on the edit page


        public StaffingErrorViewModel()
        {

        }

        public StaffingErrorViewModel(StaffingError error)
        {
            this.AssignedAt = error.AssignedAt;
            this.AssignedByUser = error.AssignedByUser;
            this.AssignedByUserId = error.AssignedByUserId;
            this.AssignedToOrg = error.AssignedToOrg;
            this.AssignedToOrgId = error.AssignedToOrgId;
            this.AssignedToUser = error.AssignedToUser;
            this.AssignedToUserId = error.AssignedToUserId;
            this.Comments = error.Comments;
            this.CreatedAt = error.CreatedAt;
            this.CreatedByUserId = error.CreatedByUserId;
            this.DataItemId = error.DataItemId;
            this.DeletedAt = error.DeletedAt;
            this.ErrorDetails = error.ErrorDetails;
            this.ErrorListId = error.ErrorListId;
            this.ErrorSummary = error.ErrorSummary;
            this.Histories = error.Histories;
            this.Notes = error.Notes;
            this.QmsErrorCode = error.QmsErrorCode;
            this.QmsKey = error.QmsKey;
            this.QmsOhrErrorId = error.QmsOhrErrorId;
            this.ResolvedAt = error.ResolvedAt;
            this.RowVersion = error.RowVersion;
            this.ShortErrorDescription = error.ShortErrorDescription;
            this.Status = error.Status;
            this.StatusId = error.StatusId;
            this.SubmittedAt = error.SubmittedAt;
            this.SystemName = error.SystemName;
            this.UpdatedAt = error.UpdatedAt;
        }

}
}
