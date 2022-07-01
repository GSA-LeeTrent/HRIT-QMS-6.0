using System;
using System.Collections.Generic;
using System.Text;

namespace Qms_Data.Model
{
    public class EmployeeCategorizationChaseListItem
    {
        public int Id { get; set; }
        public string EmplId { get; set; }
        public string Employee { get; set; }
        public string DepartmentId { get; set; }
        public string AgencySubElement { get; set; }
        public string PersonnelOfficeId { get; set; }
        public string PersonnelOfficeLabel { get; set; }
        public string ReportedOnPositionNumber { get; set; }
        public string CurrentPositionNumber { get; set; }
        public int PositionCategoryId { get; set; }
        public string Categorization { get; set; }
        public DateTime FromDate { get; set; }
        public string UpdatedBy { get; set; }
        public string ChaseReason { get; set; }

        public string FromDateDisplay { get { return FromDate.ToString("MM-dd-yyyy"); } }

    }
}
