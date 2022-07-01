using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class NtfNotificationuserpreference
    {
        public int NotificationUserPreferenceId { get; set; }
        public uint UserId { get; set; }
        public int NotificationEventId { get; set; }
        public bool? MessageDeliveryIsOn { get; set; }
        public bool CanBeTurnedOffByUser { get; set; }

        public virtual NtfNotificationevent NotificationEvent { get; set; }
        public virtual SecUser User { get; set; }
    }
}
