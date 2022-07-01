using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class NtfNotification
    {
        public int NotificationId { get; set; }
        public uint UserId { get; set; }
        public int NotificationEventId { get; set; }
        public uint WorkitemId { get; set; }
        public string WorkItemTypeCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public sbyte Hasbeenread { get; set; }
        public DateTime? ReadAt { get; set; }
        public sbyte Sendasemail { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual NtfNotificationevent NotificationEvent { get; set; }
        public virtual SecUser User { get; set; }
        public virtual QmsWorkitemtype WorkItemTypeCodeNavigation { get; set; }
    }
}
