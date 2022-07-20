using AutoMapper;
using Qms_Data.Repositories;
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
        public readonly IMapper _mapper;

        public UserAdminService()
        {
            _repository = new UserAdminRepository();

            MapperConfiguration mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<SecUser, UserAdminFormVM>().ReverseMap();
                cfg.CreateMap<SecUser, UserListRowVM>().ReverseMap();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public IList<UserListRowVM> RetrieveActiveUsers()
        {
            return this.mapToViewModel(_repository.RetrieveActiveUsers());
        }

        public IList<UserListRowVM> RetrieveInactiveUsers()
        {
            return this.mapToViewModel(_repository.RetrieveInactiveUsers());
        }

        public List<ManagerSelectOptionVM> RetrieveUsersByOrgId(int orgId)
        {
            IQueryable<SecUser> entities = _repository.RetrieveUsersByOrgId(orgId);

            List<ManagerSelectOptionVM> viewModels = new();
            foreach (SecUser entity in entities)
            {
                viewModels.Add(new ManagerSelectOptionVM(Convert.ToString(entity.UserId),  $"{entity.DisplayName} - [{entity.EmailAddress}]"));
            }
            return viewModels;
        }

        public IList<RoleVM> RetrieveActiveRoles()
        {
            IQueryable<SecRole> entities = _repository.RetrieveActiveRoles();

            IList<RoleVM> viewModels = new List<RoleVM>();
            foreach (SecRole entity in entities)
            {
                viewModels.Add(new RoleVM((int)entity.RoleId, entity.RoleCode, entity.RoleLabel));
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

        public int CreateUser(UserAdminFormVM uaForm, string[] selectedRoleIdsForUser)
        {
            SecUser entity = _mapper.Map<SecUser>(uaForm);

            int[] roleIdsAsInts = Array.ConvertAll(selectedRoleIdsForUser, int.Parse);

            return 0;
        }
    }
}
