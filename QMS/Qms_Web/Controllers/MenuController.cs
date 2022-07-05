using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QmsCore.Services;
using QmsCore.UIModel;

namespace Qms_Web.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuBuilderService _menuBuilderService;

        public MenuController(IMenuBuilderService menuBuilderService)
        {
            _menuBuilderService = menuBuilderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Menu_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<ModuleMenuItem> moduleMenuItems = _menuBuilderService.RetrieveMenuForUser(140);

            foreach (var mmi in moduleMenuItems)
            {
                System.Console.WriteLine();
                System.Console.WriteLine(mmi);
                System.Console.WriteLine();
            }

            return Json(moduleMenuItems);
        }
    }
}
