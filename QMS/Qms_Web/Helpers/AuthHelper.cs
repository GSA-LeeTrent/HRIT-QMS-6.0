using Microsoft.AspNetCore.Authentication.Cookies;
using QmsCore.UIModel;
using System.Security.Claims;
using System.Text;

namespace Qms_Web.Helpers
{
    public static class AuthHelper
    {
        public static ClaimsPrincipal CreateClaimsPrincipal(User qmsUser, string userName, string email)
        {
            string logSnippet = new StringBuilder("[")
                                .Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                                .Append("][AuthHelper][CreateClaimsPrincipal] => ")
                                .ToString();

            Console.WriteLine(logSnippet + $"(p_userName): '{userName}'");
            Console.WriteLine(logSnippet + $"(p_email)...: '{email}'");
            Console.WriteLine(logSnippet + $"(qmsUser == null): {qmsUser == null}");

            var claimsIdentity
                = new ClaimsIdentity
                    (CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, userName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, email));

            Console.WriteLine(logSnippet + $"(roleCount): {qmsUser!.UserRoles.Count}");

            foreach (var userRole in qmsUser.UserRoles)
            {
                Console.WriteLine(logSnippet + $"(role): '{userRole.Role.RoleCode}'");
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, userRole.Role.RoleCode));
            }

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
