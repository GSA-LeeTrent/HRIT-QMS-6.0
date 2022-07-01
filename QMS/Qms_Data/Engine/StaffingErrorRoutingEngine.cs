using QmsCore.Model;
using QmsCore.Repository;
using QmsCore.Services;
using QmsCore.UIModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QmsCore.Engine
{
    internal class StaffingErrorRoutingEngine : BaseRoutingEngine
    {
        StaffingError error;
        StaffingErrorService service;
        StaffingErrorRepository repository;
        //ReferenceRepository referenceRepository;
        public StaffingErrorRoutingEngine(StaffingErrorService oneHrService)
        {
            service = oneHrService;
            referenceRepository = new ReferenceRepository();
            repository = service.repository;
        }

        internal int ExecuteUpdates(StaffingError oneHrError, User submittedBy, string history,string actionStatus)
        {
            submitter = submittedBy;
            error = oneHrError;
            error.UpdatedAt = DateTime.Now;
            // OHR_Closed,OHR_Returned,OHR_PendingReview,OHR_Assigned (message 2 params, title 1 param)
            if (actionStatus == StatusType.UNASSIGNED)
            {
                throw new Exception("Staffing Errors cannot be unassigned");
            }
            else if (actionStatus == StatusType.ASSIGNED)
            {
                ActionDescription = string.Format("{0} assigned error<br/>{1}", submitter.DisplayName, history);
                service.addHistory(error, submitter, ActionDescription);
                NotificationEventType = StaffingErrorNotificationType.SA_Assigned;
                AssignToUser(error);
            }
            else if (actionStatus == StatusType.CLOSED)
            {
                ActionDescription = string.Format("{0} closed error<br/>{1}", submitter.DisplayName, history);
                service.addHistory(error, submitter, ActionDescription);
                NotificationEventType = StaffingErrorNotificationType.SA_Closed;
                Close(error);
            }
            else if (actionStatus == StatusType.CLOSED_ACTION_COMPLETED)
            {
                ActionDescription = string.Format("{0} completed error<br/>{1}", submitter.DisplayName, history);
                service.addHistory(error, submitter, ActionDescription);
                NotificationEventType = StaffingErrorNotificationType.SA_Closed;
                CloseActionCompleted(error);
            }
            else if (actionStatus == StatusType.PENDING_REVIEW)
            {
                ActionDescription = string.Format("{0} submitted error for review<br/>{1}", submitter.DisplayName, history);
                service.addHistory(error, submitter, ActionDescription);
                NotificationEventType = StaffingErrorNotificationType.SA_PendingReview;
                SubmitForReview(error);
            }

            QmsStfacqError qmsOhrError = error.QmsOhrError();
            repository.Update(qmsOhrError);
            repository.context.SaveChanges();


            return error.QmsOhrErrorId;
        }


        void AssignToUser(StaffingError entity)
        {
            entity.StatusId = (uint)referenceRepository.GetStatus(StatusType.ASSIGNED).StatusId;
            entity.AssignedAt = DateTime.Now;
            entity.AssignedByUserId = (uint)submitter.UserId;
            entity.AssignedToOrgId = (uint)submitter.OrgId;

        }
        void Close(StaffingError entity)
        {
            entity.StatusId = (uint)referenceRepository.GetStatus(StatusType.CLOSED).StatusId;
            entity.ResolvedAt = DateTime.Now;

        }
        void CloseActionCompleted(StaffingError entity)
        {
            entity.StatusId = (uint)referenceRepository.GetStatus(StatusType.CLOSED_ACTION_COMPLETED).StatusId;
            entity.ResolvedAt = DateTime.Now;

        }
        void SubmitForReview(StaffingError entity)
        {
            entity.AssignedToOrgId = (uint)submitter.OrgId;
            entity.StatusId = (uint)referenceRepository.GetStatus(StatusType.PENDING_REVIEW).StatusId;
        }
    }
}
