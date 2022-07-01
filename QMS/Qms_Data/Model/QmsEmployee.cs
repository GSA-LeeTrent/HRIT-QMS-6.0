using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsEmployee
    {
        public QmsEmployee()
        {
            EpcEmployeepositioncategory = new HashSet<EpcEmployeepositioncategory>();
            QmsCorrectiveactionrequest = new HashSet<QmsCorrectiveactionrequest>();
            QmsDataerror = new HashSet<QmsDataerror>();
        }

        public string EmplId { get; set; }
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
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string UserKey { get; set; }
        public string PositionNbr { get; set; }

        public virtual ICollection<EpcEmployeepositioncategory> EpcEmployeepositioncategory { get; set; }
        public virtual ICollection<QmsCorrectiveactionrequest> QmsCorrectiveactionrequest { get; set; }
        public virtual ICollection<QmsDataerror> QmsDataerror { get; set; }
    }
}
