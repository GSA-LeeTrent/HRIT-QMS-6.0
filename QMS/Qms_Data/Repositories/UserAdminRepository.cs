﻿using Microsoft.EntityFrameworkCore;
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

        public IQueryable<SecRole> RetrieveActiveRoles()
        {
            return _dbContext.SecRole.AsNoTracking().Where(p => p.DeletedAt == null).OrderBy(s => s.RoleCode);
        }

        public int CreateUser(SecUser secUser)
        {
            _dbContext.SecUser.Add(secUser);
            foreach (var sur in secUser.SecUserRole)
            {
                _dbContext.SecUserRole.Add(sur);
            }
            _dbContext.SaveChanges();
            return (int)secUser.UserId;
        }

        public SecUser RetrieveUserByEmailAddress(string emailAddress)
        {
            return _dbContext.SecUser.AsNoTracking().Where(u => u.EmailAddress == emailAddress).SingleOrDefault();
        }
    }
}