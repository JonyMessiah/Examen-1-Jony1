using DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.Controllers
{
    public class AuthorsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthorList()
        {
            return View();
        }

    }

}