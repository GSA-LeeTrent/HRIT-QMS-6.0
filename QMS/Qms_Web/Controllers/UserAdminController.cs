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
            ViewData["ShowUserAdminActiveTab"] = "True";
            ViewData["ShowUserAdmiInactiveTab"] = "False";

            return View();
        }

        public IActionResult _ActiveUsers()
        {
            Console.WriteLine("\n[UserAdminController][ActiveUsers] =>\n");

            //ViewData["ShowUserAdminActiveTab"] = "true"; 
            //ViewData["ShowUserAdmiInactiveTab"] = "false";

            return PartialView(_userService.RetrieveActiveUsers());
        }

        public IActionResult _InactiveUsers()
        {
            Console.WriteLine("\n[UserAdminController][InactiveUsers] =>\n");

            //ViewData["ShowUserAdminActiveTab"] = "false";
            //ViewData["ShowUserAdmiInactiveTab"] = "true"; 

            return PartialView(_userService.RetrieveInactiveUsers());
        }
    }
}
