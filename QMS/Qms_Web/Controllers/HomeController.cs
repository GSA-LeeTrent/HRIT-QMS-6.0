using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Qms_Web.Constants;
using Qms_Web.Extensions;
using QmsCore.Services;
using QmsCore.UIModel;
using System.Diagnostics;
using System.Text;

namespace Qms_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet("/")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult UnauthorizedAccess()
        {
            return View();
        }


        [Authorize(Roles = "SYS_ADMINZZZZZZZZZZZZZZZZZZZZZZZZ")]
        public IActionResult ChangeLog()
        {
            return View();
        }
    }
}