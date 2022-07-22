using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qms_Data.ViewModels
{
    public class RoleVM
    {
        public RoleVM(int roleId, string roleCode, string roleLabel)
        {
            RoleId = roleId;
            RoleCode = roleCode;
            RoleLabel = roleLabel;
        }

        public int RoleId { get; }
        public string RoleCode { get; }
        public string RoleLabel { get; }
        public bool Selected { get; set; } = false;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("RoleVM = {");
            sb.Append("RoleId: ");
            sb.Append(this.RoleId);
            sb.Append(", RoleCode: ");
            sb.Append(this.RoleCode);
            sb.Append(", RoleLabel: ");
            sb.Append(this.RoleLabel);
            sb.Append(", Selected: ");
            sb.Append(this.Selected);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
