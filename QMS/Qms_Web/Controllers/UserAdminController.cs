using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using QmsCore.Services;
using QmsCore.UIModel;
using Qms_Web.Models;

namespace Qms_Web.Controllers
{
    public class UserAdminController : Controller
    {
        private readonly IUserService _userService;

        public UserAdminController(IUserService userService)
        {
            Console.WriteLine("\n[UserAdminController][Constructor] =>");
            _userService = userService;
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

            List<User> activeUsers = _userService.RetrieveActiveUsers();
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

            List<User> inactiveUsers = _userService.RetrieveInactiveUsers();
            var dsResult = inactiveUsers.ToDataSourceResult(request);
            return Json(dsResult);
        }
    }
}
