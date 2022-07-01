using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QmsCore.Model
{
    public partial class SysSettingtype
    {
        public SysSettingtype()
        {
            SysSetting = new HashSet<SysSetting>();
        }

        public int SettingTypeId { get; set; }
        public string SettingCode { get; set; }
        public string SettingDescription { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime? Deletedat { get; set; }

        public virtual ICollection<SysSetting> SysSetting { get; set; }
    }
}
