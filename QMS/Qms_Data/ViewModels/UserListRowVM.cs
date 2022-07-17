using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qms_Data.ViewModels
{
    public class UserListRowVM
    {
        public UserListRowVM(int userId, string emailAddress, string displayName, string organizationName, string managerName)
        {
            UserId = userId;
            EmailAddress = emailAddress;
            DisplayName = displayName;
            OrganizationName = organizationName;
            ManagerName = managerName;
        }

        public int UserId { get; }
        public string EmailAddress { get; }
        public string DisplayName { get; }
        public string OrganizationName { get; }
        public string ManagerName { get;  }
    }
}
