using QmsCore.Model;
using QmsCore.Repository;
using QmsCore.Services;
using QmsCore.UIModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QmsCore.Engine
{
    internal class StaffingErrorNotificationEngine : BaseNotificationEngine
    {
        private StaffingErrorRepository repository;

        public StaffingErrorNotificationEngine() : base()
        {
            repository = new StaffingErrorRepository();
        }

        public StaffingErrorNotificationEngine(QMSContext qMSContext) : base(qMSContext)
        {
            repository = new StaffingErrorRepository(qMSContext);
        }

        public void Send(StaffingError error, string notificationEventCode, User submitter)
        {
            notificationEvent = notificationRepository.RetrieveNotificationEventByCode(notificationEventCode);
            originator = userRepository.RetrieveByUserId((int)error.CreatedByUserId.Value);
            bool willSendtoSubmitter = ((originator.UserId == submitter.UserId) && (notificationEvent.NotificationEventType.NotificationEventTypeCode == NotificationEventType.INDIV));
            if (!willSendtoSubmitter)
            {
                notificationEventType = notificationEvent.NotificationEventType;
                switch (notificationEventType.NotificationEventTypeCode)
                {
                    case NotificationEventType.INDIV:
                        sendIndividualMessage(error, notificationEvent, submitter);
                        break;
                    case NotificationEventType.ORG:
                        sendOrganizationalMessage(error, notificationEvent);
                        break;
                    default:
                        break;
                }

            }
        }

        internal string formatMessage(StaffingError error)
        {
            template = "Staffing Error ID: {0}<br/>System: {1}<br/>Error Description: {2}<br/>Created At:{3}<br/<br/>Updated on: {4}<br/><br/>";
            string dateToUse = error.UpdatedAt.HasValue ? error.UpdatedAt.Value.ToShortDateString() : error.CreatedAt.ToShortDateString();

            message = string.Format(template, error.Id, error.SystemName, error.ShortErrorDescription, error.ErrorSummary, dateToUse);
            return message;
        }

        internal void sendIndividualMessage(StaffingError error, NtfNotificationevent ne, User submitter)
        {
            try
            {
                if (submitter.UserId != error.CreatedByUserId.Value) // if the person doing the action is the originator they don't get a message since they did the action
                {

                    SecUser user;
                    NtfNotification notification = new NtfNotification();
                    notification.CreatedAt = DateTime.Now;
                    notification.HasBeenRead = 0;
                    notification.Title = string.Format(ne.TitleTemplate, error.Id); //HRQMS - EHRI Error Closed ({0})
                    notification.WorkitemId = (uint)error.Id;
                    notification.WorkItemTypeCode = WorkItemTypeEnum.StaffAcquisition;
                    notification.SendAsEmail = 0; //Changed from 1 so it doesn't send
                    notification.NotificationEventId = ne.NotificationEventId;
                    notification.Message = formatMessage(error);
                    switch (ne.NotificationEventCode)
                    {
                        case StaffingErrorNotificationType.SA_Assigned:
                        case StaffingErrorNotificationType.SA_PendingReview:
                        case StaffingErrorNotificationType.SA_Closed:
                        case StaffingErrorNotificationType.SA_Returned:
                            notification.UserId = error.AssignedByUserId.Value;
                            break;
                        default:
                            //not a indivual message type
                            break;
                    }

                    if (notification.UserId > 0) //0 = System user - no need to notify.
                    {
                        context.Add(notification);
                        context.SaveChanges();
                        user = userRepository.RetrieveByUserId((int)notification.UserId);
                        send(user.EmailAddress, notification.Title, notification.Message);
                    }
                }
            }
            catch (Exception x)
            {
                System.Console.WriteLine(x.StackTrace);
            }
        }



        internal void sendOrganizationalMessage(StaffingError error, NtfNotificationevent ne)
        {
            try
            {
                List<SecUser> users = getReviewersInOrgByRoleName((int)error.AssignedToOrgId.Value, "SC_REVIEWER");
                string[] emails = new string[users.Count];
                NtfNotification notification = new NtfNotification();
                notification.CreatedAt = DateTime.Now;
                notification.Title = string.Format(ne.TitleTemplate, error.Id);
                notification.Message = formatMessage(error);
                notification.HasBeenRead = 0;
                notification.WorkitemId = (uint)error.Id;
                notification.WorkItemTypeCode = WorkItemTypeEnum.StaffAcquisition;
                notification.SendAsEmail = 0; //Changed from 1 so it doesn't send
                notification.NotificationEventId = ne.NotificationEventId;

                int i = 0;
                foreach (var user in users)
                {
                    NtfNotification newNotification = notification.Clone();
                    newNotification.UserId = user.UserId;
                    context.Add(newNotification);
                    emails[i] = user.EmailAddress;
                    i++;

                }
                context.SaveChanges();
                send(emails, notification.Title, notification.Message);
            }
            catch (Exception x)
            {
                System.Console.WriteLine(x.StackTrace);
            }
        }
    }
}
