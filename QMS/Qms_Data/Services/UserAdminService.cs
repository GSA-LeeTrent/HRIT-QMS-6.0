﻿using Qms_Data.Repositories;
using Qms_Data.Repositories.Interfaces;
using Qms_Data.Services.Interfaces;
using Qms_Data.ViewModels;
using QmsCore.Model;
using System.Collections.Generic;
using System.Linq;

namespace Qms_Data.Services
{
    public class UserAdminService : IUserAdminService
    {
        private readonly IUserAdminRepository _repository;

        public UserAdminService()
        {
            _repository = new UserAdminRepository();
        }

        public IList<UserListRowVM> RetrieveActiveUsers()
        {
            IQueryable<SecUser> entities = _repository.RetrieveActiveUsers();
            IList<UserListRowVM> viewModels = new List<UserListRowVM>();
            foreach (SecUser entity in entities)
            {
                viewModels.Add(new UserListRowVM (
                    (int)entity.UserId,
                    entity.EmailAddress,
                    entity.DisplayName,
                    (entity.Org == null) ? "" : entity.Org.OrgLabel,
                    (entity.Manager == null) ? "" : entity.Manager.DisplayName)
                );
            }
            return viewModels;
        }

        public IList<UserListRowVM> RetrieveInactiveUsers()
        {
            IQueryable<SecUser> entities = _repository.RetrieveInactiveUsers();
            IList<UserListRowVM> viewModels = new List<UserListRowVM>();
            foreach (SecUser entity in entities)
            {
                viewModels.Add(new UserListRowVM(
                    (int)entity.UserId,
                    entity.EmailAddress,
                    entity.DisplayName,
                    (entity.Org == null) ? "" : entity.Org.OrgLabel,
                    (entity.Manager == null) ? "" : entity.Manager.DisplayName)
                );
            }
            return viewModels;
        }
    }
}
