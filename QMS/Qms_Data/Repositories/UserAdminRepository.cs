using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public SecUser RetrieveUserByUserId(int userId, bool skinny = false)
        {
            if (skinny)
            {
                return _dbContext.SecUser.AsNoTracking().Where(u => u.UserId == userId).SingleOrDefault();
            }

            return _dbContext.SecUser
                                .AsNoTracking()
                                .Where(u => u.UserId == userId)
                                .Include(u => u.Org)
                                .Include(u => u.Manager)
                                .Include(u => u.SecUserRole).ThenInclude(u => u.Role).ThenInclude(r => r.SecRolePermission).ThenInclude(r => r.Permission)
                                .SingleOrDefault();
        }
        public void UpdateUser(SecUser entityToUpdate)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////
            // PURGE EXISTING ROLES FIRST BECAUSE WE ARE DOING A DELETE FOLLOWWED BY AN INSERT FOR ROLES
            ///////////////////////////////////////////////////////////////////////////////////////////////
            IQueryable<SecUserRole> suRoles = _dbContext.SecUserRole.Where(r => r.UserId == entityToUpdate.UserId);
            _dbContext.SecUserRole.RemoveRange(suRoles);
            _dbContext.SaveChanges();

            ///////////////////////////////////////////////////////////////////////////////////////////////
            // MAKE SURE THAT THE DATABASE ENTITIES ARE IN A DETACHED STATE BEFORE PERFORMING UPDATE
            ///////////////////////////////////////////////////////////////////////////////////////////////
            //IEnumerable<EntityEntry> entityEntries = _dbContext.ChangeTracker.Entries();
            //foreach (var entityEntry in entityEntries)
            //{
            //    entityEntry.State = EntityState.Detached;
            //}

            ///////////////////////////////////////////////////////////////////////////////////////////////
            // RETRIEVE THE EXISTING 'CreatedAt' VALUE BEFORE PERFORMING THE UPDATE
            ///////////////////////////////////////////////////////////////////////////////////////////////
            SecUser existingEntity = this.RetrieveUserByUserId((int)entityToUpdate.UserId, skinny: true);
            entityToUpdate.CreatedAt = existingEntity.CreatedAt;

            ///////////////////////////////////////////////////////////////////////////////////////////////
            // SET THE 'UpdatedAt'
            ///////////////////////////////////////////////////////////////////////////////////////////////
            entityToUpdate.UpdatedAt = DateTime.Now;

            ///////////////////////////////////////////////////////////////////////////////////////////////
            // SAVE CHANGES TO DATABASE
            ///////////////////////////////////////////////////////////////////////////////////////////////
            _dbContext.SecUser.Update(entityToUpdate);
            _dbContext.SaveChanges();
        }

        public SecUser DeactivateUser(int userId)
        {
            SecUser deactivatedUser = this.RetrieveUserByUserId(userId, skinny: true);
            deactivatedUser.DeletedAt = DateTime.Now;
            _dbContext.SecUser.Update(deactivatedUser);
            int updateCount = _dbContext.SaveChanges();

            return deactivatedUser;
        }

        public SecUser ReactivateUser(int userId)
        {
            SecUser reactivatedUser = this.RetrieveUserByUserId(userId, skinny: true);
            reactivatedUser.DeletedAt = null;
            _dbContext.SecUser.Update(reactivatedUser);
            int updateCount = _dbContext.SaveChanges();

            return reactivatedUser;
        }
    }
}