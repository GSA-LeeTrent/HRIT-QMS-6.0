using Qms_Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qms_Data.Services.Interfaces
{
    public interface IUserAdminService
    {
        public IList<UserListRowVM> RetrieveActiveUsers();
        public IList<UserListRowVM> RetrieveInactiveUsers();
        public List<ManagerSelectOptionVM> RetrieveUsersByOrgId(int orgId);
        public IList<RoleVM> RetrieveActiveRoles();
        public int CreateUser(UserAdminFormVM uaForm, string[] selectedRoleIdsForUser);
    }
}
