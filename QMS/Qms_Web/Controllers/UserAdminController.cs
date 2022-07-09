using Microsoft.AspNetCore.Mvc;

namespace Qms_Web.Controllers
{
    public class UserAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ActiveUsers()
        {
            Console.WriteLine("\n[UserAdminController][ActiveUsers] =>\n");
            return View();
        }

        public IActionResult InactiveUsers()
        {
            Console.WriteLine("\n[UserAdminController][InactiveUsers] =>\n");
            return View();
        }
    }
}
