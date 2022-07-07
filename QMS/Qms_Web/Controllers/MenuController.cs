﻿using Kendo.Mvc.UI;
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
            List<ModuleMenuItem> parentMenus = _menuBuilderService.RetrieveMenuForUser(140);

            foreach (var parentMenu in parentMenus)
            {
                List<QmsCore.UIModel.MenuItem> childMenus = parentMenu.MenuItems;
                foreach (var childMenu in childMenus)
                {
                    childMenu.MenuUrlField = Url.Action(childMenu.ControllerAction, childMenu.Controller);
                }
            }
 
            foreach (var parentMenu in parentMenus)
            {
                System.Console.WriteLine();
                System.Console.WriteLine(parentMenu);
                System.Console.WriteLine();
            }

            return Json(parentMenus);
        }
    }
}
