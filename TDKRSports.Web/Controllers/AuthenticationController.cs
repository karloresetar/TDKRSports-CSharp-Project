using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TDKRSports.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery]string user, [FromQuery]string pwd)
        {
            if ( user == "admin" && pwd == "adminadmin")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user),
                    new Claim(ClaimTypes.Email, "admin@admin.com"),
                };
                var userIdentity = new ClaimsIdentity(userClaims, "TDKRSports.CookieAuth");
                var userPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync("TDKRSports.CookieAuth", userPrincipal);
            }
            return Redirect("/outstandingorders");
        }
        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/outstandingorders");
        }
    }
}
