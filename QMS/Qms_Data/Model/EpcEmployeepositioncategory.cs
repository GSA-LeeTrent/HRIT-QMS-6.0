using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class EpcEmployeepositioncategory
    {
        public int EmployedPositionCategoryId { get; set; }
        public string EmplId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string PositionNbr { get; set; }
        public int PositionCategoryId { get; set; }
        public string PositionNeedsToBeInLocation { get; set; }
        public sbyte? EstimatedDaysInOffice { get; set; }
        public string BusinessReason { get; set; }
        public string Comments { get; set; }
        public uint UpdatedByUserId { get; set; }

        public virtual QmsEmployee Empl { get; set; }
        public virtual EpcPositioncategory PositionCategory { get; set; }
        public virtual SecUser UpdatedByUser { get; set; }
    }
}
