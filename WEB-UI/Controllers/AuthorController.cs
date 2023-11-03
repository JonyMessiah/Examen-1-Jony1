using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
