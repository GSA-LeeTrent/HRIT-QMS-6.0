using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using QmsCore.Services;
using QmsCore.UIModel;
using Qms_Web.Models;
using QMS.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Qms_Web.Controllers
{
    [Authorize(Roles = "SYS_ADMIN")]
    public class UserAdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IOrganizationService _organizationService;

        public UserAdminController(IUserService userService, IRoleService roleService, IOrganizationService organizationService)
        {
            _userService = userService;
            _roleService = roleService;
            _organizationService = organizationService;
        }


        ////////////////////////////////////////////////////////////////////////////////
        // INDEX PAGE CONTAINING ACTIVE AND INACTIVE TABS
        ////////////////////////////////////////////////////////////////////////////////
        public IActionResult Index()
        {
            ViewData["ShowUserAdminActiveTab"] = "True";
            ViewData["ShowUserAdmiInactiveTab"] = "False";

            return View();
        }


        ////////////////////////////////////////////////////////////////////////////////
        // ACTIVE USERS TAB
        ////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult _ActiveUsers()
        {
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
            List<User> activeUsers = _userService.RetrieveActiveUsers();
            var dsResult = activeUsers.ToDataSourceResult(request);
            return Json(dsResult);
        }


        ////////////////////////////////////////////////////////////////////////////////
        // INACTIVE USERS TAB
        ////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult _InactiveUsers()
        {
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

            List<User> inactiveUsers = _userService.RetrieveInactiveUsers();
            var dsResult = inactiveUsers.ToDataSourceResult(request);
            return Json(dsResult);
        }


        ////////////////////////////////////////////////////////////////////////////////
        // ADD NEW USER
        ////////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult AddNewUser()
        {
            Console.WriteLine("\n[UserAdminController][AddNewUser][GET] =>");

            UserFormViewModel userFormVM = new UserFormViewModel
            {
                Mutatatable = true,
                Deactivatable = false,
                Reactivatable = false,
                AspAction = "Create",
                SubmitButtonLabel = "Create",
                CardHeader = "Create QMS User:",
            };

            ////////////////////////////////////////////////////////////////////////////////
            // ALL SELECTABLE USER ROLES
            ////////////////////////////////////////////////////////////////////////////////
            List<Role> allActiveDbRoles = _roleService.RetrieveActiveRoles();
            foreach (Role activeDbRole in allActiveDbRoles)
            {
                userFormVM.CheckboxRoles.Add(this.createUARoleViewModel(activeDbRole));
            }

            ////////////////////////////////////////////////////////////////////////////////
            // ALL SELECTABLE ORGANIZATIONS
            ////////////////////////////////////////////////////////////////////////////////
            List<Organization> activeOrganizations = _organizationService.RetrieveActiveOrganizations();
            ViewBag.ActiveOrganizations = new SelectList(activeOrganizations, "OrgId", "OrgLabel");

            ////////////////////////////////////////////////////////////////////////////////
            // POTENTIAL MANAGERS
            List<User> usersInOrg = new List<User>();
            ViewBag.PotentialManagers = new SelectList(usersInOrg, "UserId", "DisplayLabel");


            return View(userFormVM);
        }

        private UARoleViewModel createUARoleViewModel(Role dbRole)
        {
            UARoleViewModel vmRole = new UARoleViewModel();

            vmRole.RoleId = dbRole.RoleId;
            vmRole.RoleCode = dbRole.RoleCode;
            vmRole.RoleLabel = dbRole.RoleLabel;

            return vmRole;
        }
    }
}
