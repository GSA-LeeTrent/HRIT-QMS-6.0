using Microsoft.AspNetCore.Mvc;

namespace Qms_Web.Controllers
{
    public class UserAdminContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
