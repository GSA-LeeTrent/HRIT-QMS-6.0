using Microsoft.AspNetCore.Mvc;
using QmsCore.Services;

namespace Qms_Web.Controllers
{
    public class UserAdminController : Controller
    {
        private readonly IUserService _userService;

        public UserAdminController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _ActiveUsers()
        {
            Console.WriteLine("\n[UserAdminController][ActiveUsers] =>\n");
            return PartialView(_userService.RetrieveActiveUsers());
        }

        public IActionResult _InactiveUsers()
        {
            Console.WriteLine("\n[UserAdminController][InactiveUsers] =>\n");
            return PartialView(_userService.RetrieveInactiveUsers());
        }
    }
}
