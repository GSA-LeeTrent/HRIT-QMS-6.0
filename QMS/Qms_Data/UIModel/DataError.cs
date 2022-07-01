using System;
using System.Collections.Generic;
using QmsCore.Lib;
using QmsCore.Model;

namespace QmsCore.UIModel
{
    public class DataError : IListable
    {
        internal int orgViewerIsFrom;
        public string Template {get {return string.Empty;}}
        public string Message {get {return string.Empty;}}
        public  List<DataErrorComment> Comments {get;set;}
        public List<DataErrorHistory> Histories {get;set;}
        public int DataErrorId { get; set; }

        public string DataElement {get;set;}
        public string DataCategory {get;set;}
        public string DataErrorKey { get; set; }
        public int ErrorListId { get; set; }
        public string EmplId { get; set; }
        public Employee Employee { get; set; }
        public string QmsErrorCode { get; set; }
        public uint? AssignedToUserId { get; set; }
        public virtual User AssignedToUser{ get; set; }        
        public uint? AssignedByUserId { get; set; }
        public User AssignedByUser {get;set;}
        public uint? AssignedToOrgId { get; set; }
        public virtual Organization AssignedToOrg { get; set; }
        public string QmsErrorMessageText { get; set; }
        public int? CorrectiveActionId { get; set; }
        public User CreatedByUser { get; set; }

        public int CreatedByOrgId {get;set;}
        public Organization CreatedByOrg {get;set;}
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int Id { get {return DataErrorId;} set {DataErrorId = value;}} 
        public DateTime? AssignedAt { get; set; }

        public string Details {get;set;}

        public uint? StatusId { get; set; }
        public Status Status { get; set; }  

        public DateTime? SubmittedAt { get; set; }

        /// <summary>
        /// Determines action to do from OrgStatusTrans Id
        /// </summary>
        /// <value></value>
        public int OrgStatusTransId {get;set;}


        public string WorkItemType {
            get {
                return Model.WorkItemTypeEnum.EHRI;
            }
        }

        public uint? CreatedByUserId { get; set; }

        public byte? RowVersion {get;set;}

        public DataError()
        {}

        public DataError(QmsDataerror error)
        {
            this.AssignedAt = error.AssignedAt;

            this.AssignedByUserId = error.AssignedByUserId;
            if(this.AssignedByUserId.HasValue)
                this.AssignedByUser = new User(error.AssignedByUser,false,false);

            this.AssignedToOrgId = error.AssignedToOrgId;
            if(this.AssignedToOrgId.HasValue)
                this.AssignedToOrg = new Organization(error.AssignedToOrg);      

            this.AssignedToUserId = error.AssignedToUserId;
            if(this.AssignedToUserId.HasValue)
                this.AssignedToUser = new User(error.AssignedToUser,false,false);

            this.CorrectiveActionId = error.CorrectiveActionId;
            this.CreatedAt = error.CreatedAt;
            this.CreatedByUserId = error.CreatedByUserId;
            this.CreatedByUser = new User(error.CreatedByUser,false,false);
            this.CreatedByOrgId = (int)error.CreatedByOrgId;
            this.CreatedByOrg = new Organization(error.CreatedByOrg);  
            this.DeletedAt = error.DeletedAt;
            this.Details = error.Details;
            this.EmplId = error.Emplid;
            this.Employee = new Employee(error.Empl);
            this.DataErrorId = error.DataErrorId;
            this.DataErrorKey = error.DataErrorKey;
            this.ErrorListId = error.ErrorListId;
            this.QmsErrorCode = error.QmsErrorCode;
            this.QmsErrorMessageText = error.QmsErrorMessageText;
            this.ResolvedAt = error.ResolvedAt;
            this.StatusId = error.StatusId;
            this.Status = new Status(error.Status);
            this.SubmittedAt = error.SubmittedAt;
            this.UpdatedAt = error.UpdatedAt;
            this.RowVersion = (byte)error.RowVersion;

            this.DataCategory = error.ErrorList.DataItem.DataItemCategory;
        }

        public DataError(QmsDataerror error, User viewer)
        {
            orgViewerIsFrom = viewer.OrgId.Value;
            this.AssignedAt = error.AssignedAt;

            this.AssignedByUserId = error.AssignedByUserId;
            if(this.AssignedByUserId.HasValue)
                this.AssignedByUser = new User(error.AssignedByUser,false,false);

            this.AssignedToOrgId = error.AssignedToOrgId;
            if(this.AssignedToOrgId.HasValue)
                this.AssignedToOrg = new Organization(error.AssignedToOrg);      

            this.AssignedToUserId = error.AssignedToUserId;
            if(this.AssignedToUserId.HasValue)
                this.AssignedToUser = new User(error.AssignedToUser,false,false);

            this.CorrectiveActionId = error.CorrectiveActionId;
            this.CreatedAt = error.CreatedAt;
            this.CreatedByUserId = (uint?)error.CreatedByUserId;
            this.CreatedByUser = new User(error.CreatedByUser,false,false);
            this.CreatedByOrgId = (int)error.CreatedByOrgId;
            this.CreatedByOrg = new Organization(error.CreatedByOrg);  
            this.DeletedAt = error.DeletedAt;
            this.Details = error.Details;
            this.EmplId = error.Emplid;
            this.Employee = new Employee(error.Empl);
            this.DataErrorId = error.DataErrorId;
            this.DataErrorKey = error.DataErrorKey;
            this.ErrorListId = error.ErrorListId;
            this.QmsErrorCode = error.QmsErrorCode;
            this.QmsErrorMessageText = error.QmsErrorMessageText;
            this.ResolvedAt = error.ResolvedAt;
            this.StatusId = error.StatusId;
            this.Status = new Status(error.Status);
            this.SubmittedAt = error.SubmittedAt;
            this.UpdatedAt = error.UpdatedAt;
            this.RowVersion = (byte)error.RowVersion;
            this.DataCategory = error.ErrorList.DataItem.DataItemCategory;   
            this.DataElement = error.ErrorList.DataItem.DataItemName;         
            setReadOnly(viewer);
        }        

        public QmsDataerror QmsDataError()
        {
            QmsDataerror q = new QmsDataerror();
            q.AssignedAt = this.AssignedAt;
            q.AssignedByUserId = this.AssignedByUserId;
            q.AssignedToOrgId = this.AssignedToOrgId.Value;
            q.AssignedToUserId = this.AssignedToUserId;
            q.CorrectiveActionId = this.CorrectiveActionId;
            q.CreatedAt = this.CreatedAt;
            q.CreatedByUserId = this.CreatedByUserId.Value;
            q.CreatedByOrgId = (uint)this.CreatedByOrgId;
            q.DeletedAt =this.DeletedAt;
            q.Details = this.Details;
            q.DataErrorId = this.DataErrorId;
            q.DataErrorKey = this.DataErrorKey;
            q.Emplid = this.EmplId;
            q.StatusId = this.StatusId.Value;
            q.ErrorListId = this.ErrorListId;
            q.QmsErrorCode = this.QmsErrorCode;
            q.QmsErrorMessageText = this.QmsErrorMessageText;
            q.ResolvedAt = this.ResolvedAt;
            q.StatusId = this.StatusId.Value;
            q.SubmittedAt = this.SubmittedAt;
            q.UpdatedAt = this.UpdatedAt;
            q.RowVersion = (sbyte)this.RowVersion;
            return q;
        }

        public DataErrorListItem DataErrorListItem()
        {
            DataErrorListItem item = new DataErrorListItem();
            item.CorrectiveActionId = this.CorrectiveActionId;
            item.DateCreated = this.CreatedAt;
            item.DaysOpen = this.DaysSinceCreated;
            item.EhriErrorId = this.DataErrorId;
            item.EmplId = this.EmplId;
            item.EmployeeName = this.Employee.FullName;
            item.ErrorCode = this.QmsErrorCode;
            item.OfficeSymbol = this.Employee.DepartmentId;
            item.Category = this.DataCategory;
            item.DataElement = this.DataElement;
            item.Priority = this.Priority;
            item.PriorityIndex  = this.PriorityIndex;
            item.Status = this.Status.StatusLabel;
            item.DataElement = this.DataElement;
            if(this.AssignedToUserId.HasValue)
                item.AssignedTo = this.AssignedToUser.DisplayName;
            return item;            
        }




        public int DaysSinceCreated {
            get { //QMS-187
                    if(!this.Status.StatusLabel.Contains("Closed")) //ticket is NOT closed
                    {
                        return DateCalc.DaysBetween(this.CreatedAt, DateTime.Now);
                    }
                    else
                    {
                        return DateCalc.DaysBetween(this.CreatedAt,this.ResolvedAt.Value);
                    }
                }
        }

        public int? DaysSinceAssigned{
            get {
                if(this.AssignedAt.HasValue)
                {
                    return DateCalc.DaysBetween(this.AssignedAt.Value, DateTime.Now);
                }
                else{
                    return null;
                }
                
            }
        }

        public string Priority{
           get{
               string retval = "Normal";
               if(PriorityIndex >=10)
               {
                   retval = "High";
               }
               else if(PriorityIndex >= 5)
               {
                   retval = "Elevated";
               }
               return retval;
           } 
        }        

        public int PriorityIndex{
            get {
                int retval = 0;
                double daysTotal = DaysSinceCreated / 10;
                int daysFactor = Convert.ToInt32(daysTotal);
                int gradeFactor = 0;

                    string payPlan = this.Employee.PayPlan;
                    if(payPlan == "AD")
                        gradeFactor = 5;

                    string employeePoid = this.Employee.PersonnelOfficeIdentifier;
                    if(employeePoid == "1909")
                        gradeFactor = 5;                

                retval = gradeFactor + daysFactor;
                return retval;
            }
        }



        public bool IsReadOnly = true;
        private void setReadOnly(User user)
        {
            bool keepChecking = true;
            string currentStatus = this.Status.StatusCode;

            //check if it's been closed for more than 30 days
            if(currentStatus == StatusType.CLOSED || currentStatus == StatusType.CLOSED_ACTION_COMPLETED || currentStatus == StatusType.CLOSED_CONVERT_TO_CORR_ACTION)
            {
                int daysOld = DateCalc.DaysBetween(this.ResolvedAt.Value,DateTime.Now);
                if(daysOld >= 30)
                {
                    keepChecking = false;
                    IsReadOnly = true;
                }
            }

            //check if user has read only permissions
            if(keepChecking)
            {
                IsReadOnly= ((UserUtil.UserHasPermission(user,  EhriErrorViewPermissionEnum.VIEW_ALL_EHRI_ERRORS)) || (UserUtil.UserHasPermission(user,  EhriErrorViewPermissionEnum.VIEW_ALL_ARCHIVED_EHRI_ERRORS)));
                keepChecking = !IsReadOnly;
            }


            //check for users with editing permissions
            if(keepChecking)
            {
                bool isSCReviewer = UserUtil.UserHasRole(user,ApplicationRoleType.SC_REVIEWER);  
                bool isSCSpecialist = UserUtil.UserHasRole(user,ApplicationRoleType.SC_SPECIALIST);
                bool isBRCReviewer = UserUtil.UserHasRole(user,ApplicationRoleType.PPRB_REVIEWER);  
                bool isBRCSpecialist = UserUtil.UserHasRole(user,ApplicationRoleType.PPRB_SPECIALIST);
                bool isPPRMReviewer = UserUtil.UserHasRole(user,ApplicationRoleType.PPRM_REVIEWER);  
                bool isPPRMSpecialist = UserUtil.UserHasRole(user,ApplicationRoleType.PPRM_SPECIALIST);                
                if(isBRCSpecialist || isSCSpecialist || isPPRMSpecialist)
                {
                    if((this.AssignedToUserId == user.UserId) || (this.CreatedByUserId == user.UserId))
                    {
                        IsReadOnly = false;  //It's assigned to them
                    }
                    else
                    {
                        IsReadOnly = true;
                    }
                }
                else if(isBRCReviewer || isSCReviewer || isPPRMReviewer)
                {
                    if((this.AssignedToOrgId == user.OrgId.Value) || (this.CreatedByOrgId == user.OrgId.Value))
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
            get{
                bool retval = false;
                try
                {
                    int i = (int)this.StatusId.Value;
                    int? orgId  = (int?)this.AssignedToOrgId;
                    int UNASSIGNED = 1;
                    int ASSIGNED = 2;
                    int PENDING_REVIEW = 3;

                    if((orgId == orgViewerIsFrom)  && (i==UNASSIGNED) || (i==PENDING_REVIEW) || (i == ASSIGNED))
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
















    }


}