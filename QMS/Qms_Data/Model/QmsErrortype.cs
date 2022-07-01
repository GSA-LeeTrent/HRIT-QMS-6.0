using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsErrortype
    {
        public QmsErrortype()
        {
            QmsCorrectiveactionErrortype = new HashSet<QmsCorrectiveactionErrortype>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string RoutesToBr { get; set; }
        public sbyte DisplayOrder { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<QmsCorrectiveactionErrortype> QmsCorrectiveactionErrortype { get; set; }
    }
}
