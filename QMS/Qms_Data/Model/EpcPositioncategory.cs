using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class EpcPositioncategory
    {
        public EpcPositioncategory()
        {
            EpcEmployeepositioncategory = new HashSet<EpcEmployeepositioncategory>();
        }

        public int PositionCategoryId { get; set; }
        public string PositionCategoryCode { get; set; }
        public string PositionCategoryLabel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<EpcEmployeepositioncategory> EpcEmployeepositioncategory { get; set; }
    }
}
