using Microsoft.AspNetCore.Mvc;

namespace Qms_Web.Controllers
{
    public class CorrectiveActionsController : Controller
    {
        public IActionResult Index(string useCase)
        {
            ViewData["UseCase"] = useCase;
            return View();
        }
    }
}
