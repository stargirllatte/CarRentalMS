using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class HelpController : Controller
    {
        // Contact Us Page
        public IActionResult ContactUs()
        {
            return View();
        }

        // How to Book Page
        public IActionResult HowToBook()
        {
            return View();
        }

        // FAQ Page
        public IActionResult FAQ()
        {
            return View();
        }
    }
}
