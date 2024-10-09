using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace OAuthDotNetCore.Controllers
{
    public class AccountController : Controller
    {
        // This method handles the login process using Microsoft OAuth.
        // It redirects the user to the Microsoft login page.
        // Once the user is authenticated, they are redirected to the provided return URL (default is "/").
        public IActionResult Login(string returnUrl = "/")
        {
            // AuthenticationProperties allows setting the URL to return to after authentication.
            var properties = new AuthenticationProperties { RedirectUri = returnUrl };

            // Challenge() sends the user to the external authentication provider (Microsoft in this case).
            // The second parameter specifies "Microsoft" as the authentication scheme.
            return Challenge(properties, "Microsoft");
        }

        // This method handles the logout process.
        // It signs the user out of the application and redirects them to the homepage ("/").
        [HttpPost] // This ensures the method is called via a POST request for security purposes.
        public IActionResult Logout()
        {
            // SignOut() signs the user out of the cookie-based session and redirects to the home page.
            // The CookieAuthenticationDefaults.AuthenticationScheme is used to specify the session management mechanism (cookies).
            return SignOut(new AuthenticationProperties { RedirectUri = "/" }, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
