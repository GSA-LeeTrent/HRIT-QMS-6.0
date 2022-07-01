using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SysSetting
    {
        public int SettingId { get; set; }
        public int SettingTypeId { get; set; }
        public string SettingValue { get; set; }
        public string Environment { get; set; }

        public virtual SysSettingtype SettingType { get; set; }
    }
}
