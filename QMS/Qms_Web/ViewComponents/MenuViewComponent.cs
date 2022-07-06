using Microsoft.AspNetCore.Mvc;
using Qms_Web.Constants;
using Qms_Web.Extensions;
using QmsCore.UIModel;

namespace Qms_Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<ModuleMenuItem> moduleMenuItems = HttpContext.Session.GetObject<List<ModuleMenuItem>>(QmsConstants.MODULE_MENU_ITEMS_SESSION_KEY)!;

            if (moduleMenuItems != null)
            {
                return View(moduleMenuItems);
            }

            return View(new List<ModuleMenuItem>());
        }
    }
}