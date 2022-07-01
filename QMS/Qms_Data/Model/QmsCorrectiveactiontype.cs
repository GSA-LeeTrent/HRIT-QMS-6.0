using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsCorrectiveactiontype
    {
        public QmsCorrectiveactiontype()
        {
            QmsCorrectiveactionrequest = new HashSet<QmsCorrectiveactionrequest>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<QmsCorrectiveactionrequest> QmsCorrectiveactionrequest { get; set; }
    }
}
