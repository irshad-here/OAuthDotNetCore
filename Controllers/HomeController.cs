using Microsoft.AspNetCore.Mvc;

namespace OAuthDotNetCore.Controllers
{
    public class HomeController: Controller
    {
        public HomeController()
        {
                
        }

        public IActionResult Index() {
            return View();
        }
    }
}
