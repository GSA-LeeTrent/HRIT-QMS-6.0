using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Qms_Data.Services.Interfaces;
using Qms_Web.Models;
using Qms_Data.ViewModels;

namespace Qms_Web.Controllers
{
    [Authorize(Roles = "SYS_ADMIN")]
    public class UserAdminController : Controller
    {
        private readonly IUserAdminService _userAdminService;

        public UserAdminController(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
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
    }
}
