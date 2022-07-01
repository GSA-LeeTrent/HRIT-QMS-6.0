using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class NtfNotificationeventtype
    {
        public NtfNotificationeventtype()
        {
            NtfNotificationevent = new HashSet<NtfNotificationevent>();
        }

        public int NotificationEventTypeId { get; set; }
        public string NotificationEventTypeCode { get; set; }
        public string NotificationEventTypeLabel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<NtfNotificationevent> NtfNotificationevent { get; set; }
    }
}
