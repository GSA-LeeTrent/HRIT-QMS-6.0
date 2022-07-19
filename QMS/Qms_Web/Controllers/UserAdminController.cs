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
            Console.WriteLine("\n[UserAdminController][Index] =>");

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
            Console.WriteLine("\n[UserAdminController][_ActiveUsers][GET] =>\n");
            return PartialView(new PagerViewModel());
        }

        [HttpPost]
        public ActionResult _ActiveUsers(PagerViewModel pager)
        {
            Console.WriteLine("\n[ActiveUsersController][_ActiveUsers][POST] =>");
            return PartialView(pager);
        }

        public ActionResult ActiveUsers_Read([DataSourceRequest] DataSourceRequest request)
        {
            Console.WriteLine("\n[UserAdminController][ActiveUsers_Read] =>");

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
            Console.WriteLine("\n[UserAdminController][InactiveUsers][GET] =>\n");

            return PartialView(new PagerViewModel());
        }

        [HttpPost]
        public ActionResult _InactiveUsers(PagerViewModel pager)
        {
            Console.WriteLine("\n[UserAdminController][InactiveUsers][POST] =>");
            return PartialView(pager);
        }

        public ActionResult InactiveUsers_Read([DataSourceRequest] DataSourceRequest request)
        {
            Console.WriteLine("\n[UserAdminController][InactiveUsers_Read] =>");

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

            // ORGANIZATION DROPDOWN
            List<Organization> activeOrganizations = _organizationService.RetrieveActiveOrganizations();
            ViewBag.ActiveOrganizations = new SelectList(activeOrganizations, "OrgId", "OrgLabel");

            // MANAGER DROPDOWN (based on user selection in Organization Dropdown)
            List<User> usersInOrg = new List<User>(); // empty to begin with
            ViewBag.PotentialManagers = new SelectList(usersInOrg, "UserId", "DisplayLabel");

            // ROLE CHECKBOXES
            uaFormVM.CheckboxRoles = _userAdminService.RetrieveActiveRoles();
  
            return View(uaFormVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser([Bind("ManagerId, OrgId, EmailAddress, DisplayName")]  UserAdminFormVM userFormVM, string[] selectedRoleIdsForUser)
        {
            return RedirectToAction("Index");
        }
    }
}
