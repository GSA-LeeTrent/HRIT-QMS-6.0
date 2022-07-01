using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QmsCore.Model;
using QmsCore.Repository;
using QmsCore.UIModel;
using QmsCore.Engine;
using QmsCore.QmsException;
using System.Text;
using QmsCore.Lib;
using Qms_Data.UIModel;
using Qms_Data.Model;

namespace QmsCore.Services
{
    public class StaffingErrorService : BaseService<QmsStfacqError>, IStaffingErrorService
    {
        const int defaultPageSize = 50;
        internal StaffingErrorRepository repository;
        ReferenceRepository referenceRepository;
        internal int archiveDayCount = -3;

        public StaffingErrorService()
        {
            repository = new StaffingErrorRepository(this.context);
        }

        public StaffingErrorService(QMSContext qmsContext)
        {
            this.context = qmsContext;
            repository = new StaffingErrorRepository(this.context);
            referenceRepository = new ReferenceRepository(this.context);

        }

        public void SaveComment(string message
                                      , int entityId
                                      , int authorId)
        {
            UIModel.StaffingErrorComment comment = new UIModel.StaffingErrorComment(message, entityId, authorId);
            QmsWorkitemcomment workItemComment = comment.WorkItemComment();
            this.context.Add(workItemComment);
            this.context.SaveChanges();
        }

        public int? Save(int errorId, string notes, int actionId, User submitter, int? assigneeId)
        {
            StaffingError error = new StaffingError(repository.RetrieveById(errorId));
            error.Notes = notes;
            StatusTransition action = referenceRepository.RetrieveOrgStatusTranstion(actionId);
            string actionStatus = action.ToStatus.StatusCode;
            error.StatusId = action.ToStatus.StatusId;

            if (assigneeId.HasValue)
            {
                error.AssignedByUserId = (uint)submitter.ID;
                error.AssignedToUserId = (uint)assigneeId;
                error.AssignedAt = DateTime.Now;
            }

            return Save(error, submitter, actionStatus);
        }

        private int? Save(StaffingError newVersion, User submitter, string actionStatus)
        {
            string history = string.Empty;
            StaffingError oldVersion = RetrieveById(newVersion.QmsOhrErrorId);
            if (newVersion.RowVersion == oldVersion.RowVersion)
            {
                history = writeHistory(newVersion, oldVersion, submitter);
                newVersion.RowVersion++;
                StaffingErrorRoutingEngine routingEngine = new StaffingErrorRoutingEngine(this);
                routingEngine.ExecuteUpdates(newVersion, submitter, history, actionStatus);
                StaffingErrorNotificationEngine notificationEngine = new StaffingErrorNotificationEngine();
                notificationEngine.Send(newVersion, routingEngine.NotificationEventType, submitter);
            }
            else
            {
                throw new LockingException(string.Format("This Staffing Error {0} was updated by another user. Old version #{1}, new version #{2}", newVersion.Id, newVersion.RowVersion, oldVersion.RowVersion));
            }

            return newVersion.QmsOhrErrorId;
        }

        internal void addHistory(StaffingError item, User actionTakenByUser, string actionDescription)
        {
            QmsWorkitemhistory itemHistory = new QmsWorkitemhistory();
            itemHistory.ActionTakenByUserId = (uint?)actionTakenByUser.UserId;
            itemHistory.CreatedAt = DateTime.Now;
            itemHistory.WorkItemId = item.QmsOhrErrorId;
            itemHistory.PreviousStatusId = item.StatusId;
            itemHistory.PreviousAssignedByUserId = item.AssignedByUserId;
            itemHistory.PreviousAssignedToOrgId = item.AssignedToOrgId;
            itemHistory.PreviousAssignedtoUserId = item.AssignedToUserId;
            itemHistory.ActionDescription = actionDescription;
            itemHistory.WorkItemTypeCode = item.WorkItemType;
            context.Add(itemHistory);
            context.SaveChanges();
        }


        private string writeHistory(StaffingError newVersion, StaffingError oldVersion, User submitter)
        {
            StringBuilder sb = new StringBuilder();
            int changeCount = 0;
            string lineBreak = "<br/>";
            if (newVersion.AssignedToUserId != oldVersion.AssignedToUserId)
            {
                UserRepository userRepo = new UserRepository(this.context);
                var newAssignee = userRepo.RetrieveByUserId((int)newVersion.AssignedToUserId).DisplayName;
                changeCount++;
                sb.AppendLine(string.Format("Staffing Error now assigned to {0}",newAssignee));
            }

            if (newVersion.Notes != oldVersion.Notes)
            {
                changeCount++;
                sb.AppendLine(string.Format(" - Details changed from: {2} {0} to {2} {1} {2}", oldVersion.Notes, newVersion.Notes, lineBreak));
            }
            return sb.ToString();
        }


        #region "CRUD Methods"

        public void Close(StaffingError error)
        {
            error.ResolvedAt = DateTime.Now;
            repository.Update(error.QmsOhrError());
        }

        public void Update(StaffingError error)
        {
            repository.Update(error.QmsOhrError());
        }


        #endregion


        #region "Retrieve Methods"


        public List<UIModel.StaffingErrorComment> RetrieveComments(int staffingErrorId)
        {
            bool enableUserSecurityLoading = false;
            var items = context.QmsWorkitemcomment.AsNoTracking().Where(c => c.WorkItemId == staffingErrorId && c.WorkItemTypeCode == WorkItemTypeEnum.StaffAcquisition).Include(c => c.WorkItemTypeCodeNavigation).Include(c => c.Author).ThenInclude(u => u.Org);
            List<UIModel.StaffingErrorComment> comments = new List<UIModel.StaffingErrorComment>();
            foreach (var item in items)
            {
                comments.Add(new UIModel.StaffingErrorComment(item, enableUserSecurityLoading));
            }
            return comments;
        }


        public StaffingError RetrieveById(int id)
        {
            StaffingError error = new StaffingError(repository.RetrieveById(id));
            var comments = repository.RetrieveComments(id);
            var history = repository.RetrieveHistory(id);
            error.loadComments(comments);
            error.loadHistory(history);
            return error;
        }

        public StaffingErrorListItemPager GetActiveRecordsAll(string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            return repository.GetActiveRecordsAll(orderBy, pageNumber, pageSize);
        }

        public StaffingErrorListItemPager GetArchiveRecordsAll(string orderBy, int pageNumber, int pageSize = defaultPageSize)
        {
            return repository.GetArchiveRecordsAll(orderBy, pageNumber, pageSize);
        }

        public StaffingErrorListItemPager GetActiveRecordsByOrg(string orderBy, int pageNumber, int orgId, int pageSize = defaultPageSize)
        {
            return repository.GetActiveRecordsByOrg(orderBy, pageNumber, orgId, pageSize);
        }

        public StaffingErrorListItemPager GetArchiveRecordsByOrg(string orderBy, int pageNumber, int orgId, int pageSize = defaultPageSize)
        {
            return repository.GetArchiveRecordsByOrg(orderBy, pageNumber, orgId, pageSize);
        }

        public StaffingErrorListItemPager GetActiveRecordsByUser(string orderBy, int pageNumber, int userId, int pageSize = defaultPageSize)
        {
            return repository.GetActiveRecordsByUser(orderBy, pageNumber, userId, pageSize);
        }

        public StaffingErrorListItemPager GetArchiveRecordsByUser(string orderBy, int pageNumber, int userId, int pageSize = defaultPageSize)
        {
            return repository.GetArchiveRecordsByUser(orderBy, pageNumber, userId, pageSize);
        }


        #endregion

    }
}
