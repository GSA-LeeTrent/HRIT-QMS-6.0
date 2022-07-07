using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qms_Web.Extensions;
using Qms_Web.Constants;
using Qms_Web.Helpers;
using QmsCore.Services;
using QmsCore.UIModel;
using System.Security.Claims;
using System.Text;

namespace Qms_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly IUserService _userService;
        private readonly IMenuBuilderService _menuBuilderService;

        /////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTOR
        /////////////////////////////////////////////////////////////////////////////////////////
        public AuthController(IWebHostEnvironment hostingEnv, IUserService userService, IMenuBuilderService menuBuilderService)
        {
            _hostingEnv = hostingEnv;
            _userService = userService;
            _menuBuilderService = menuBuilderService;
        }

        [HttpGet("unauthorized")]
        [Authorize]
        public IActionResult AccessDenied()
        {
            ViewData["Title"] = "Access Denied";
            return View();
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        // LOGOUT [GET]
        /////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        // LOGIN [GET]
        /////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][AuthenticationController][HttpGet][LoginAsync] => ")
                                .ToString();
            Console.WriteLine($"{logSnippet} (returnUrl): '{returnUrl}'");

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        // LOGOUT [POST]
        /////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][AuthenticationController][HttpPost][LoginAsync] => ")
                                .ToString();
            Console.WriteLine($"{logSnippet} (returnUrl): '{returnUrl}'");
            Console.WriteLine($"{logSnippet} ((_hostingEnv.IsDevelopment()): '{_hostingEnv.IsDevelopment()}'");

            if (_hostingEnv.IsDevelopment())
            {
                string localhostEmail = Environment.GetEnvironmentVariable("LOCALHOST_EMAIL")!;
                string localhostName  =  Environment.GetEnvironmentVariable("LOCALHOST_NAME")!;
                Console.WriteLine(logSnippet + $"Bypassing SecureAuth and authenticating as [{localhostName}][{localhostEmail}]");

                ////////////////////////////////////////////////////////////////////////////
                // SecUser 
                ////////////////////////////////////////////////////////////////////////////
                User qmsUser = _userService.RetrieveByEmailAddress(localhostEmail);
                var claimsPrincipal = AuthHelper.CreateClaimsPrincipal(qmsUser, localhostName, localhostEmail);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                HttpContext.Session.SetObject(QmsConstants.USER_SESSION_KEY, qmsUser);
                ////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////
                // QMS Navigation Menu APPEARING ON ALL PAGES
                ////////////////////////////////////////////////////////////////////////////
                List<ModuleMenuItem> moduleMenuItems = _menuBuilderService.RetrieveMenuForUser(qmsUser.UserId);
                HttpContext.Session.SetObject(QmsConstants.MODULE_MENU_ITEMS_SESSION_KEY, moduleMenuItems);
                ////////////////////////////////////////////////////////////////////////////





                return Redirect(returnUrl);
            }
            return View("login");
        }
    }
}
