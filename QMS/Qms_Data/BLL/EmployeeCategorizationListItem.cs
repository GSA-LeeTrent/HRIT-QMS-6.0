using System;
using System.Collections.Generic;
using System.Text;

namespace Qms_Data.Model
{
    public class EmployeeCategorizationListItem
    {

        public int Id { get; set; }
        public string EmplId { get; set; }
        public string Employee { get; set; }
        public string DepartmentId { get; set; }
        public string AgencySubElement { get; set; }
        public int PersonnelOfficeId { get; set; }
        public string PersonnelOfficeLabel { get; set; }
        public string ReportedOnPositionNumber { get; set; }
        public string CurrentPositionNumber { get; set; }
        public int CategorizationId { get; set; }
        public string Categorization { get; set; }
        public string PositionNeedsToBeInLocation { get; set; }
        public int? EstimatedDaysInOffice { get; set; }
        public string BusinessReason { get; set; }
        public string Comments { get; set; }
        public DateTime FromDate { get; set; }
        public string LastUpdatedBy { get; set; } 

        public int DaysInOfficeDisplayValue
        {
            get
            {
                return EstimatedDaysInOffice.HasValue ? EstimatedDaysInOffice.Value : -1;
            }
            set 
            {
                EstimatedDaysInOffice = value;
            }
        }

        public string FromDateDisplay { get { return FromDate.ToString("MM-dd-yyyy"); } }

    }
}
