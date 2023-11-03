using Microsoft.AspNetCore.Mvc;
using DTO.Models;

namespace WEB_UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Cancel() 
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(User user) 
        {
            if (user.UserName == null || user.Password == null)
            {
                ViewBag.Message = "Usuario y/o password incorrectos";
                return View();
            }

            //Hacer el proceso de verificar el usuario contra la DB
            //API-->AdminLogin-->LoginCrud-->DAO-->DB

            //En caso de que el usuario esté ok, se habilita la sesion

            user.FullName = "Isaias Chavarria M.";

            //llenar los valores en la sesion
            HttpContext.Session.SetString("user", user.FullName);

            return RedirectToAction("Index", "Home");
        }

    }
}
