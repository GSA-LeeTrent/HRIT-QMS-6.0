﻿using Qms_Data.Repositories;
using Qms_Data.Repositories.Interfaces;
using Qms_Data.Services.Interfaces;
using Qms_Data.ViewModels;
using QmsCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return this.mapToViewModel(_repository.RetrieveActiveUsers());
        }

        public IList<UserListRowVM> RetrieveInactiveUsers()
        {
            return this.mapToViewModel(_repository.RetrieveInactiveUsers());
        }

        public List<UserInOrgVM> RetrieveUsersByOrgId(int orgId)
        {
            List<SecUser> entities = _repository.RetrieveUsersByOrgId(orgId).ToList();

            string logSnippet = new StringBuilder("[")
                    .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                    .Append("][UserAdminService][RetrieveUsersByOrgId] => ")
                    .ToString();
            Console.WriteLine(logSnippet + $"(entities.Count)..: '{entities.Count}'");

            List<UserInOrgVM> viewModels = new();
            foreach (SecUser entity in entities)
            {
                viewModels.Add(new UserInOrgVM(
                    Convert.ToString(entity.UserId),
                    (entity.OrgId.HasValue) ? Convert.ToString(entity.OrgId.Value) : null,
                    entity.EmailAddress,
                    entity.DisplayName
                ));
            }
            return viewModels;
        }

        private IList<UserListRowVM> mapToViewModel(IQueryable<SecUser> entities)
        {
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
