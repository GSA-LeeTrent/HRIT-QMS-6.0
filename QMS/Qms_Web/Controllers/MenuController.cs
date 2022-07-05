using Microsoft.AspNetCore.Mvc;

namespace Qms_Web.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
