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
            uint[] roleIdsAsInts = Array.ConvertAll(selectedRoleIdsForUser, uint.Parse);

            entity.SecUserRole = new List<SecUserRole>();
            foreach (uint roleId in roleIdsAsInts)
            {
                SecUserRole sur = new SecUserRole
                {
                    RoleId = roleId,
                    UserId = 0,
                    CreatedAt = DateTime.Now,
                };
                entity.SecUserRole.Add(sur);
            }
          
            return _repository.CreateUser(entity);
        }

        public bool UserAlreadyExists(string emailAddress)
        {
            return _repository.RetrieveUserByEmailAddress(emailAddress) != null;
        }
        public UserAdminFormVM RetrieveUserByUserId(int userId)
        {
            SecUser secUser = _repository.RetrieveUserByUserId(userId);
            UserAdminFormVM uaFormVM = _mapper.Map<UserAdminFormVM>(secUser);

            uaFormVM.CheckboxRoles = this.RetrieveActiveRoles();

            HashSet<int> availableRowIdSet = new HashSet<int>(uaFormVM.CheckboxRoles.Select(r => r.RoleId));
            HashSet<uint> assignedRoleIdSet = new HashSet<uint>(secUser.SecUserRole.Select(sur => sur.RoleId));
            foreach (RoleVM checkboxRole in uaFormVM.CheckboxRoles)
            {
                checkboxRole.Selected = assignedRoleIdSet.Contains((uint)checkboxRole.RoleId);
            }
            return uaFormVM;
        }

        public void UpdateUser(UserAdminFormVM uaForm, string[] selectedRoleIdsForUser)
        {
            SecUser entityToUpdate = _mapper.Map<SecUser>(uaForm);

            uint[] roleIdsAsInts = Array.ConvertAll(selectedRoleIdsForUser, uint.Parse);
            entityToUpdate.SecUserRole = new List<SecUserRole>();

            foreach (uint roleId in roleIdsAsInts)
            {
                SecUserRole sur = new SecUserRole
                {
                    RoleId = roleId,
                    UserId = 0,
                    CreatedAt = DateTime.Now,
                };
                entityToUpdate.SecUserRole.Add(sur);
            }

           _repository.UpdateUser(entityToUpdate);
        }
    }
}
