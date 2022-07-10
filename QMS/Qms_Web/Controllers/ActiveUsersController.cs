using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using QmsCore.Services;
using QmsCore.UIModel;
using Qms_Web.Models;

namespace Qms_Web.Controllers
{
    public class ActiveUsersController : Controller
    {
        private readonly IUserService _userService;

        public ActiveUsersController(IUserService userService)
        {
            Console.WriteLine("\n[ActiveUsersController][Constructor] =>");
            _userService = userService;
        }

        public ActionResult Paging()
        {
            Console.WriteLine("\n[ActiveUsersController][Paging][GET] =>");
            return View(new PagerViewModel());
        }

        [HttpPost]
        public ActionResult Paging(PagerViewModel pager)
        {
            Console.WriteLine("\n[ActiveUsersController][Paging][POST] =>");
            return View(pager);
        }

        public ActionResult ActiveUsers_Read([DataSourceRequest] DataSourceRequest request)
        {
            Console.WriteLine("\n[ActiveUsersController][ActiveUsers_Read] =>");

            List<User> activeUsers = _userService.RetrieveActiveUsers();
            var dsResult = activeUsers.ToDataSourceResult(request);
            return Json(dsResult);
        }
    }
}
