using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class EpcEmployeepositiontobevalidated
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
        public int PositionCategoryId { get; set; }
        public string Categorization { get; set; }
        public DateTime FromDate { get; set; }
        public uint UpdatedByUserId { get; set; }
        public string UpdatedBy { get; set; }
        public string ChaseReason { get; set; }
    }
}
