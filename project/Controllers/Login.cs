using Microsoft.AspNetCore.Mvc;
using project.Models;
using Microsoft.AspNetCore.Http;

namespace project.Controllers
{
    public class Login : Controller
    {
        private readonly ApplicationDbContext _db;

        public Login(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult log()
        {
            return View();
        }

        [HttpPost]
        public ActionResult log(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);

            if (user != null && user.Password == password)
            {
                // Store session data
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Email);

                // Redirect user to home page after login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "البريد الإلكتروني أو كلمة السر غير صحيحة.";
                return View();
            }
        }

    }
}
