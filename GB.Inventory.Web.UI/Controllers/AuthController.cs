using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;
using GB.Inventory.Business;

namespace GB.Inventory.Web.UI.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]))
            {
                HttpContext.Session.SetString("ReturnUrl", HttpContext.Request.Query["ReturnUrl"]);
            }
            return View();           
        }

        [HttpPost]
        public IActionResult Index(Model.User user)
        {
            Model.User storedUser;            
            AuthService service = new AuthService();            

            if (service.IsValidUser(user.UserName, user.Password, out storedUser))
            {
                Response.Cookies.Append("UserId", storedUser.UserId.ToString());
                Response.Cookies.Append("UserName", storedUser.UserName.ToString());
                Response.Cookies.Append("OfficeName", storedUser.OfficeName.ToString());
                Response.Cookies.Append("OfficeId", storedUser.OfficeId.ToString());
                Response.Cookies.Append("Department", storedUser.Department.ToString());

                var claims = new[]
                {
                    new Claim("UserId", storedUser.UserId.ToString()),
                    new Claim("UserName", storedUser.UserName.ToString()),
                    new Claim("OfficeName", storedUser.OfficeName.ToString()),
                    new Claim("OfficeId", storedUser.OfficeId.ToString()),
                    new Claim("Department", storedUser.Department.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                string returnUrl = HttpContext.Session.GetString("ReturnUrl");

                // Log.Information("User {UserName} logged in.", user.UserName);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return base.Redirect(returnUrl);
                }
                else
                {
                    return base.RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                // Log.Information("User with {Ip} attempted log in.", HttpContext.Connection.RemoteIpAddress);
                return base.View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return base.RedirectToAction("Index", "Home");
        }
    }
}
