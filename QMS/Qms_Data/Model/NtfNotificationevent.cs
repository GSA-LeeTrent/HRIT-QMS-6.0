using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class NtfNotificationevent
    {
        public NtfNotificationevent()
        {
            NtfNotification = new HashSet<NtfNotification>();
            NtfNotificationuserpreference = new HashSet<NtfNotificationuserpreference>();
        }

        public int NotificationEventId { get; set; }
        public string NotificationEventCode { get; set; }
        public string NotificationEventLabel { get; set; }
        public int? NotificationEventTypeId { get; set; }
        public string MessageTemplate { get; set; }
        public string TitleTemplate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual NtfNotificationeventtype NotificationEventType { get; set; }
        public virtual ICollection<NtfNotification> NtfNotification { get; set; }
        public virtual ICollection<NtfNotificationuserpreference> NtfNotificationuserpreference { get; set; }
    }
}
