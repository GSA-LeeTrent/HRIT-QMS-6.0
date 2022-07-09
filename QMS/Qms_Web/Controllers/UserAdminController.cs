using Microsoft.AspNetCore.Mvc;

namespace Qms_Web.Controllers
{
    public class UserAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _ActiveUsers()
        {
            Console.WriteLine("\n[UserAdminController][ActiveUsers] =>\n");
            return PartialView();
        }

        public IActionResult _InactiveUsers()
        {
            Console.WriteLine("\n[UserAdminController][InactiveUsers] =>\n");
            return PartialView();
        }
    }
}
