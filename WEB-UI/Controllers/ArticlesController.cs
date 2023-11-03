using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ArticleList()
        {
            return View();
        }

        public IActionResult CreateArticle()
        {
            if (HttpContext.Session.GetString("user") == null)
                return RedirectToAction("Index", "Home");

            return View();
        }
    }
}
