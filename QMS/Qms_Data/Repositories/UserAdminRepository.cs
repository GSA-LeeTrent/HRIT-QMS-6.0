using Microsoft.EntityFrameworkCore;
using Qms_Data.Repositories.Interfaces;
using QmsCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qms_Data.Repositories
{
    public class UserAdminRepository : IUserAdminRepository
    {
        private readonly QMSContext _dbContext;

        public UserAdminRepository()
        {
            _dbContext = new QMSContext();
        }

        public IQueryable<SecUser> RetrieveActiveUsers()
        {
            return _dbContext.SecUser.Where(u => u.DeletedAt == null && u.UserId > 0)
                                        .Include(u => u.Org)
                                        .Include(u => u.Manager)
                                        .OrderBy(u => u.EmailAddress)
                                        .AsNoTracking();
        }

        public IQueryable<SecUser> RetrieveInactiveUsers()
        {
            return _dbContext.SecUser.Where(u => u.DeletedAt != null && u.UserId > 0)
                                        .Include(u => u.Org)
                                        .Include(u => u.Manager)
                                        .OrderBy(u => u.EmailAddress)
                                        .AsNoTracking();
        }

        public IQueryable<SecUser> RetrieveUsersByOrgId(int orgId)
        {
            return _dbContext.SecUser.Where(u => u.DeletedAt == null && u.OrgId == orgId).AsNoTracking();
        }
    }
}