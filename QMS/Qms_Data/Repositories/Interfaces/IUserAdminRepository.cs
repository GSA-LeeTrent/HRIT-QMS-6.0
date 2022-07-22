using QmsCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qms_Data.Repositories.Interfaces
{
    public interface IUserAdminRepository
    {
        public IQueryable<SecUser> RetrieveActiveUsers();
        public IQueryable<SecUser> RetrieveInactiveUsers();
        public IQueryable<SecUser> RetrieveUsersByOrgId(int orgId);
        public IQueryable<SecRole> RetrieveActiveRoles();
        public int CreateUser(SecUser secUser);
        public SecUser RetrieveUserByEmailAddress(string emailAddress);

        public SecUser RetrieveUserByUserId(int userId);

        public void UpdateUser(SecUser secUser);
    }
}