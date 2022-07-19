using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qms_Data.ViewModels
{
    public class UserInOrgVM
    {
        public UserInOrgVM(string userId, string orgId, string emailAddress, string displayLabel)
        {
            UserId = userId;
            OrgId = orgId;
            EmailAddress = emailAddress;
            DisplayLabel = displayLabel;
        }

        public string UserId { get; }
        public string OrgId { get; }
        public string EmailAddress { get; }
        public string DisplayLabel { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("UserInOrgVM = {");
            sb.Append("UserId: ");
            sb.Append(this.UserId);
            sb.Append(", OrgId: ");
            sb.Append(this.OrgId);
            sb.Append(", EmailAddress: ");
            sb.Append(this.EmailAddress);
            sb.Append(", DisplayLabel: ");
            sb.Append(this.DisplayLabel);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
