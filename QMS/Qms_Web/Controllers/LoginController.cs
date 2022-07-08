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
using AspNetCore.LegacyAuthCookieCompat;
using QmsCore.QmsException;

namespace Qms_Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly IUserService _userService;
        private readonly IMenuBuilderService _menuBuilderService;

        public LoginController
            (
                IConfiguration config, 
                IWebHostEnvironment hostingEnv, 
                IUserService userService, 
                IMenuBuilderService menuBuilderService
            )
        {
            _config = config;
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

        public IActionResult UnauthorizedUser()
        {
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

            HttpContext.Session.SetObject(QmsConstants.REQUESTED_URI, returnUrl);
            Console.WriteLine(logSnippet + "User has not been authenticated, redirecting to SecureAuth based on parameters in the config file.");
            var samlEndpoint = _config["SecureAuth:RedirectURL"];
            Console.WriteLine(logSnippet + $"(_hostingEnv.EnvironmentName): '{_hostingEnv.EnvironmentName}'");
            Console.WriteLine(logSnippet + $"Redirecting to '{samlEndpoint}'");
            return Redirect(samlEndpoint);
        }

        public async Task<IActionResult> ExternalLoginCallback()
        {
            User? qmsUser = null;
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][LoginController][ExternalLoginCallback] => ")
                                .ToString();

            /////////////////////////////////////////////////////////////////////////////
            // This is the SecureAuth callback, which is reached by a 302. The token that
            // SecureAuth sends is a cookie.
            /////////////////////////////////////////////////////////////////////////////
            var tokenName = _config.GetValue<string>("SecureAuth:TokenName");
            Console.WriteLine(logSnippet + $"(SecureAuth:TokenName IS NULL): {tokenName == null}");
            Console.WriteLine(logSnippet + $"(tokenName): '{tokenName}'");

            string token = Request.Cookies[tokenName!]!;
            Console.WriteLine(logSnippet + $"(SecureAuth Cookie IS NULL): {token == null}");
            Console.WriteLine(logSnippet + $"(SecureAuth Cookie): '{token}'");

            if (token != null)
            {
                ////////////////////////////////////////////////////////////////////////////////
                // Decrypt the token with our SecureAuth keys (validation and decryption)
                ////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////
                // Validation Key
                ////////////////////////////////////////////////////////////////////////////////
                string validationKey = _config["SecureAuth:ValidationKey:Failover"];
                Console.WriteLine(logSnippet + $"(validationKey IS NULL): {validationKey == null}");
                Console.WriteLine(logSnippet + $"(validationKey): {validationKey}");

                ////////////////////////////////////////////////////////////////////////////////
                // Decryption Key
                ////////////////////////////////////////////////////////////////////////////////
                string decryptionKey = _config["SecureAuth:DecryptionKey:Failover"];
                Console.WriteLine(logSnippet + $"(decryptionKey IS NULL): {decryptionKey == null}");
                Console.WriteLine(logSnippet + $"(decryptionKey): {decryptionKey}");

                byte[] decryptionKeyBytes = HexUtils.HexToBinary(decryptionKey);
                byte[] validationKeyBytes = HexUtils.HexToBinary(validationKey);

                string compatabilityMode = _config.GetValue<string>(QmsConstants.ENCRYPTION_COMPATABILITY_MODE);
                Console.WriteLine(logSnippet + $"(compatabilityMode IsNullOrEmpty).....: {String.IsNullOrEmpty(compatabilityMode)}");
                Console.WriteLine(logSnippet + $"(compatabilityMode IsNullOrWhiteSpace): {String.IsNullOrWhiteSpace(compatabilityMode)}");
                Console.WriteLine(logSnippet + $"(compatabilityMode)...................: '{compatabilityMode}'");

                LegacyFormsAuthenticationTicketEncryptor? legacyFormsAuthenticationTicketEncryptor = null;

                if (compatabilityMode.Equals(QmsConstants.FRAMEWORK45))
                {
                    legacyFormsAuthenticationTicketEncryptor
                        = new LegacyFormsAuthenticationTicketEncryptor(decryptionKeyBytes, validationKeyBytes, ShaVersion.Sha1, CompatibilityMode.Framework45);
                }
                else
                {
                    legacyFormsAuthenticationTicketEncryptor
                        = new LegacyFormsAuthenticationTicketEncryptor(decryptionKeyBytes, validationKeyBytes, ShaVersion.Sha1, CompatibilityMode.Framework20SP2);
                }

                Console.WriteLine(logSnippet + $"Decrypting post-authentication cookie sent back from SecureAuth ...");
                FormsAuthenticationTicket decryptedTicket = legacyFormsAuthenticationTicketEncryptor.DecryptCookie(token);
                Console.WriteLine(logSnippet + $"(decryptedTicket IS NULL): {decryptedTicket == null}");

                if (decryptedTicket != null)
                {
                    Console.WriteLine(logSnippet + $"(decryptedTicket.Name).....: '{decryptedTicket.Name}'");
                    Console.WriteLine(logSnippet + $"(decryptedTicket.UserData).: '{decryptedTicket.UserData}'");

                    HttpContext.Session.SetObject(QmsConstants.USER_EMAIL_ADDRESS, decryptedTicket.UserData);
                }

                ////////////////////////////////////////////////////////////////////////////////
                // If user is already authenticated but user names don't match, log user out.
                ////////////////////////////////////////////////////////////////////////////////
                Console.WriteLine(logSnippet + $"(User.Identity.IsAuthenticated): '{User!.Identity!.IsAuthenticated}'");

                ////////////////////////////////////////////////////////////////////////////////
                // User is Authenticated
                ////////////////////////////////////////////////////////////////////////////////
                if (User.Identity.IsAuthenticated == true)
                {
                    Console.WriteLine(logSnippet + $"(decryptedTicket.UserData): '{decryptedTicket!.UserData}'");
                    Console.WriteLine(logSnippet + $"(decryptedTicket.Name)....: '{decryptedTicket.Name}'");
                    Console.WriteLine(logSnippet + $"(User.Identity.Name)......: '{User.Identity.Name}'");

                    if (decryptedTicket.Name != User.Identity.Name)
                    {
                        Console.WriteLine(logSnippet + $"decryptedTicket.Name AND User.Identity.Name DON'T MATCH - logging user out");
                        return await LogoutAsync();
                    }
                }

                ////////////////////////////////////////////////////////////////////////////////
                // User is NOT Authenticated
                ////////////////////////////////////////////////////////////////////////////////
                if (User.Identity.IsAuthenticated == false)
                {
                    Console.WriteLine(logSnippet + $"Calling UserService.RetrieveByEmailAddress for: '{decryptedTicket!.UserData}'");

                    try
                    {
                        qmsUser = _userService.RetrieveByEmailAddress(decryptedTicket.UserData, true);
                    }
                    catch (UserNotFoundException)
                    {
                        /////////////////////////////////////////////////////////////////////////////////////////
                        // User record not found in the sec_user table. Redirecting to 'UnauthorizedUser page.
                        /////////////////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine(logSnippet + $"qmsUser NOT FOUND for '{decryptedTicket.UserData}'. Redirecting to 'UnauthorizedUser page");
                        return RedirectToAction("UnauthorizedUser", "Login");
                    }

                    if (qmsUser.UserRoles == null || qmsUser.UserRoles.Count < 1)
                    {
                        ///////////////////////////////////////////////////////////////////////////////////////
                        // User is Unauthorized to use QMS (no roles)(No rows found insec_user_org_role table)
                        ///////////////////////////////////////////////////////////////////////////////////////
                        Console.WriteLine(logSnippet + $"No QMS roles found for authenticated user '{decryptedTicket.UserData}'. Redirecting to 'UnauthorizedUser page.");
                        return RedirectToAction("UnauthorizedUser", "Auth");
                    }

                    Console.WriteLine(logSnippet + $"'{decryptedTicket.UserData}' IS AUTHORIZED to use QMS. Creating ClaimsPrincipal.");

                    var claimsPrincipal = AuthHelper.CreateClaimsPrincipal(qmsUser, decryptedTicket.Name, decryptedTicket.UserData);

                    if (claimsPrincipal == null)
                    {
                        // ViewBag.LoginError = _localizer["User {0} does not have access to QMS.", decryptedTicket.Name];
                        ViewBag.LoginError = $"User '{decryptedTicket.Name}' does not have access to QMS.";
                    }
                    else
                    {
                        Console.WriteLine(logSnippet + $"Calling HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal)");

                        ////////////////////////////////////////////////////////////////////////////
                        // Place SecUser in Session
                        ////////////////////////////////////////////////////////////////////////////
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                        HttpContext.Session.SetObject(QmsConstants.USER_SESSION_KEY, qmsUser);


                        ////////////////////////////////////////////////////////////////////////////
                        // QMS Navigation Menu APPEARING ON ALL PAGES
                        ////////////////////////////////////////////////////////////////////////////
                        List<ModuleMenuItem> moduleMenuItems = _menuBuilderService.RetrieveMenuForUser(qmsUser.UserId);
                        HttpContext.Session.SetObject(QmsConstants.MODULE_MENU_ITEMS_SESSION_KEY, moduleMenuItems);
                        ////////////////////////////////////////////////////////////////////////////

                    }
                }
            }

            string requestedUri = HttpContext.Session.GetObject<string>(QmsConstants.REQUESTED_URI)!;

            Console.WriteLine(logSnippet + $"(Request.Protocol): '{Request.Protocol}'");
            Console.WriteLine(logSnippet + $"(Request.Host)....: '{Request.Host}'");
            Console.WriteLine(logSnippet + $"(Request.PathBase): '{Request.PathBase}'");
            Console.WriteLine(logSnippet + $"(requestedUri)....: '{requestedUri}'");

            string? redirectUrl = null;
            if (requestedUri.Equals("/") )
            {
                redirectUrl = $"https://{Request.Host}{Request.PathBase}";
            }
            else
            {
                redirectUrl = $"https://{Request.Host}{Request.PathBase}/{requestedUri}";
            }         
            Console.WriteLine(logSnippet + $"(redirectUrl).....: '{redirectUrl}'");

            if (string.IsNullOrEmpty(requestedUri) == false && string.IsNullOrWhiteSpace(requestedUri) == false)
            {
                HttpContext.Session.Remove(QmsConstants.REQUESTED_URI);
                return Redirect(redirectUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
