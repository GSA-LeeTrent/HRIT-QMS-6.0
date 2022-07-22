using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qms_Web.Constants;
using Qms_Web.Extensions;
using QmsCore.Services;
using QmsCore.UIModel;
using static Qms_Web.Constants.QmsConstants;

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

        public ActionResult Menu_Read([DataSourceRequest] DataSourceRequest request)
        {
            List<ModuleMenuItem> parentMenus = HttpContext.Session.GetObject<List<ModuleMenuItem>>(MenuConstants.MODULE_MENU_ITEMS_SESSION_KEY)!;
            if (parentMenus == null)
            {
                return View(new List<ModuleMenuItem>());
            }

            foreach (var parentMenu in parentMenus)
            {
                List<QmsCore.UIModel.MenuItem> childMenus = parentMenu.MenuItems;
                foreach (var childMenu in childMenus)
                {
                    if (childMenu.Controller.Equals("User2")) { childMenu.Controller = "UserAdmin"; }
                    if (childMenu.Controller.Equals("Role")) { childMenu.Controller = "RoleAdmin"; }
                    if (childMenu.Controller.Equals("Permission")) { childMenu.Controller = "PermissionAdmin"; }

                    if (string.IsNullOrEmpty(childMenu.UseCase) == false
                            && string.IsNullOrWhiteSpace(childMenu.UseCase) == false)
                    {
                        childMenu.MenuUrlField = Url.Action(childMenu.ControllerAction, childMenu.Controller, new { UseCase = childMenu.UseCase });
                    }
                    else
                    {
                        childMenu.MenuUrlField = Url.Action(childMenu.ControllerAction, childMenu.Controller);
                    }
                }
            }

            //foreach (var parentMenu in parentMenus)
            //{
            //    System.Console.WriteLine();
            //    System.Console.WriteLine(parentMenu);
            //    System.Console.WriteLine();
            //}

            return Json(parentMenus);
        }
    }
}
