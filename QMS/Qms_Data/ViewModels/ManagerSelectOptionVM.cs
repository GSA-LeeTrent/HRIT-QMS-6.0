using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qms_Data.ViewModels
{
    public class ManagerSelectOptionVM
    {
        public ManagerSelectOptionVM(string userId, string displayLabel)
        {
            UserId = userId;
            DisplayLabel = displayLabel;
        }

        public string UserId { get; }
        public string DisplayLabel { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("UserInOrgVM = {");
            sb.Append("UserId: ");
            sb.Append(this.UserId);
            sb.Append(", DisplayLabel: ");
            sb.Append(this.DisplayLabel);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
