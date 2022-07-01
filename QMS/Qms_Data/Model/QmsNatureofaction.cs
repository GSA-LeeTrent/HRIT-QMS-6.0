using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsNatureofaction
    {
        public QmsNatureofaction()
        {
            QmsCorrectiveactionrequest = new HashSet<QmsCorrectiveactionrequest>();
        }

        public string Noacode { get; set; }
        public string Description { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string ShortDescription { get; set; }
        public string RoutesToBr { get; set; }

        public virtual ICollection<QmsCorrectiveactionrequest> QmsCorrectiveactionrequest { get; set; }
    }
}
