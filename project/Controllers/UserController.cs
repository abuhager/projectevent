using Microsoft.AspNetCore.Mvc;

namespace project.Controllers
{
    public class UserController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            // قم بتسجيل الخروج من الـ Identity أو من الـ Session
            return RedirectToAction("Index", "Home");
        }
        
    }
}
