using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Qms_Data.Services.Interfaces;
using Qms_Web.Models;
using Qms_Data.ViewModels;
using QmsCore.Services;
using QmsCore.UIModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Qms_Web.Controllers
{
    [Authorize(Roles = "SYS_ADMIN")]
    public class UserAdminController : Controller
    {
        private readonly IUserAdminService _userAdminService;
        private readonly IOrganizationService _organizationService;

        public UserAdminController(IUserAdminService userAdminService, IOrganizationService organizationService)
        {
            _userAdminService = userAdminService;
            _organizationService = organizationService;
        }

        public IActionResult Index()
        {
            ViewData["ShowUserAdminActiveTab"] = "True";
            ViewData["ShowUserAdmiInactiveTab"] = "False";

            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////
        // ACTIVE USERS
        ////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult _ActiveUsers()
        {
            return PartialView(new PagerViewModel());
        }

        [HttpPost]
        public ActionResult _ActiveUsers(PagerViewModel pager)
        {
            return PartialView(pager);
        }

        public ActionResult ActiveUsers_Read([DataSourceRequest] DataSourceRequest request)
        {
            IList<UserListRowVM> activeUsers = _userAdminService.RetrieveActiveUsers();
            var dsResult = activeUsers.ToDataSourceResult(request);
            return Json(dsResult);
        }

        ////////////////////////////////////////////////////////////////////////////////
        // INACTIVE USERS
        ////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult _InactiveUsers()
        {
            return PartialView(new PagerViewModel());
        }

        [HttpPost]
        public ActionResult _InactiveUsers(PagerViewModel pager)
        {
            return PartialView(pager);
        }

        public ActionResult InactiveUsers_Read([DataSourceRequest] DataSourceRequest request)
        {
            IList<UserListRowVM> inactiveUsers = _userAdminService.RetrieveInactiveUsers();
            var dsResult = inactiveUsers.ToDataSourceResult(request);
            return Json(dsResult);
        }

        ////////////////////////////////////////////////////////////////////////////////
        // CREATE  USER
        ////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult CreateUser()
        {
            UserAdminFormVM uaFormVM = new UserAdminFormVM()
            {
                Mutatatable = true,
                Deactivatable = false,
                Reactivatable = false,
                AspAction = "CreateUser",
                SubmitButtonLabel = "Create",
                CardHeader = "Add New User:"
            };

            this.populateOrganizationAndManagerDropdowns(uaFormVM);
            this.populateRoleCheckboxes(uaFormVM);

            return View(uaFormVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser([Bind("ManagerId, OrgId, EmailAddress, DisplayName")]  UserAdminFormVM uaFormVM, string[] selectedRoleIdsForUser)
        {
            ///////////////////////////////////////////////////////////////////////////////////
            // User's Role Selection Validation
            ///////////////////////////////////////////////////////////////////////////////////
            if (selectedRoleIdsForUser == null || selectedRoleIdsForUser.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Please select at least one role.");
            }

            if (ModelState.IsValid)
            {
                int newUserId = _userAdminService.CreateUser(uaFormVM, selectedRoleIdsForUser);
                return RedirectToAction(nameof(Index));
            }

            uaFormVM.Mutatatable = true;
            uaFormVM.Deactivatable = false;
            uaFormVM.Reactivatable = false;
            uaFormVM.AspAction = "CreateUser";
            uaFormVM.SubmitButtonLabel = "Create";
            uaFormVM.CardHeader = "Add New User:";

            this.populateOrganizationAndManagerDropdowns(uaFormVM);
            this.populateRoleCheckboxes(uaFormVM);

            return View(uaFormVM);
        }

        private void populateOrganizationAndManagerDropdowns(UserAdminFormVM uaFormVM)
        {
            // ORGANIZATIONS
            List<Organization> activeOrganizations = _organizationService.RetrieveActiveOrganizations();
            if (uaFormVM.OrgId.HasValue && uaFormVM.OrgId.Value > 0)
            {
                ViewBag.ActiveOrganizations = new SelectList(activeOrganizations, "OrgId", "OrgLabel", uaFormVM.OrgId);
            }
            else
            {
                ViewBag.ActiveOrganizations = new SelectList(activeOrganizations, "OrgId", "OrgLabel");
            }

            if (uaFormVM.OrgId.HasValue && uaFormVM.OrgId.Value > 0
                    && uaFormVM.ManagerId.HasValue && uaFormVM.ManagerId.Value > 0)
            {
                int orgId = uaFormVM.OrgId.Value;
                List<ManagerSelectOptionVM> usersInOrg = _userAdminService.RetrieveUsersByOrgId(orgId);
                ViewBag.PotentialManagers = new SelectList(usersInOrg, "UserId", "DisplayLabel", uaFormVM.ManagerId);
            }
            else
            {
                List<User> usersInOrg = new List<User>();
                ViewBag.PotentialManagers = new SelectList(usersInOrg, "UserId", "DisplayLabel");
            }
        }

        private void populateRoleCheckboxes(UserAdminFormVM uaFormVM)
        {
            uaFormVM.CheckboxRoles = _userAdminService.RetrieveActiveRoles();
        }
    }
}
