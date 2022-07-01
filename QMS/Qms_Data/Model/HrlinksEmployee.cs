using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class HrlinksEmployee
    {
        public string EmplId { get; set; }
        public string Ssn { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AgencySubElement { get; set; }
        public string PersonnelOfficeIdentifier { get; set; }
        public string DepartmentId { get; set; }
        public string PayPlan { get; set; }
        public string Grade { get; set; }
        public string ManagerId { get; set; }
        public string Userkey { get; set; }
        public string PositionNbr { get; set; }
    }
}
