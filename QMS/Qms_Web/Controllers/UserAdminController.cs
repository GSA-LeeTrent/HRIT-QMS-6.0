using Microsoft.AspNetCore.Mvc;

namespace Qms_Web.Controllers
{
    public class UserAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
