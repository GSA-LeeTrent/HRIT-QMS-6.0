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
using static Qms_Web.Constants.QmsConstants;
using Qms_Web.Extensions;

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

            string? successMsg = HttpContext.Session.GetObject<string>(UserAdminConstants.SUCCESS_MESSAGE);
            if (String.IsNullOrEmpty(successMsg) == false && String.IsNullOrWhiteSpace(successMsg) == false)
            {
                ViewData["UserAdminSuccessMessage"] = successMsg;
                HttpContext.Session.Remove(UserAdminConstants.SUCCESS_MESSAGE);
            }         

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
            if (selectedRoleIdsForUser == null || selectedRoleIdsForUser.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Please select at least one role.");
            }

            if (_userAdminService.UserAlreadyExists(uaFormVM.EmailAddress))
            {
                ModelState.AddModelError(string.Empty, $"The following email address is already in the QMS system: '{uaFormVM.EmailAddress}'.");
            }

            if (ModelState.IsValid)
            {
                int newUserId = _userAdminService.CreateUser(uaFormVM, selectedRoleIdsForUser);
                string successMsg = $"New QMS User has been successfully added as: '{uaFormVM.DisplayName} - [{uaFormVM.EmailAddress}]'.";
                HttpContext.Session.SetObject(UserAdminConstants.SUCCESS_MESSAGE, successMsg);

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
            this.assignRoleCheckboxSelections(uaFormVM, selectedRoleIdsForUser!);

            return View(uaFormVM);
        }

        ////////////////////////////////////////////////////////////////////////////////
        // UPDATE  USER
        ////////////////////////////////////////////////////////////////////////////////
        public IActionResult UpdateUser()
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

        public IActionResult _UserAdminForm()
        {
            return PartialView();
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

        private void assignRoleCheckboxSelections(UserAdminFormVM uaFormVM, string[] selectedRoleIdStringArray)
        {
            // CONVERT STRING ARRAY TO INTEGER ARRAY
            int[] selectedRoleIdIntArray = Array.ConvertAll(selectedRoleIdStringArray, int.Parse);

            // CONVERT INTEGER ARRAY TO SET OF INTEGERS
            HashSet<int> selectedRoleIdIntSet = new HashSet<int>(selectedRoleIdIntArray);

            // For every occurrence of CheckboxRole, set the 'Selected" property to true 
            // where the role id is containted in selectedRoleIdIntSetForUser.
            foreach (RoleVM checkboxRole in uaFormVM.CheckboxRoles)
            {
                checkboxRole.Selected = selectedRoleIdIntSet.Contains(checkboxRole.RoleId);
            }
        }
    }
}
