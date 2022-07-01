using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QMS.ViewModels
{
    public class StaffingErrorListItemModel
    {
        public int ErrorId { get; set; }
        public string SystemName { get; set; }
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }
        public int AssignedToUserId { get; set; }
        public string AssignedToUserName { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AssignedToOrgId { get; set; }
        public string AssignedToOrgName { get; set; }
        public string DataItemName { get; set; }
        public string DataItemCategory { get; set; }
        public string ErrorSummary { get; set; }
        public int PriorityIndex { get; set; }
        public string PriorityDescription { get; set; }
        public string QmsKey { get; set; }
    }
}
