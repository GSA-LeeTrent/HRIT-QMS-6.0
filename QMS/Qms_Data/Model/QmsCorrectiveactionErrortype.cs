using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class QmsCorrectiveactionErrortype
    {
        public int Id { get; set; }
        public int CorrectiveActionId { get; set; }
        public int ErrorTypeId { get; set; }

        public virtual QmsCorrectiveactionrequest CorrectiveAction { get; set; }
        public virtual QmsErrortype ErrorType { get; set; }
    }
}
