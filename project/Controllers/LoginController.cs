using Microsoft.AspNetCore.Mvc;
using project.Models;

namespace project.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Login/Log
        public IActionResult Log()
        {
            return View();
        }

        // POST: /Login/Log
        [HttpPost]
        public IActionResult Log(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "البريد الإلكتروني وكلمة المرور مطلوبة";
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "بيانات دخول غير صحيحة";
                return View();
            }

            // Set session or authentication here
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.Name);

            return RedirectToAction("Index", "Home");
        }
    }
}