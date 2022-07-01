using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class StfacqSysUser
    {
        public string UserId { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserLastName { get; set; }
        public string UserFirstName { get; set; }
        public string UserStatus { get; set; }
        public string SystemName { get; set; }
    }
}
