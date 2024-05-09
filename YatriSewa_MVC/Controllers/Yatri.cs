using Microsoft.AspNetCore.Mvc;

namespace YatriSewa_MVC.Controllers
{
    public class Yatri : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Landing()
        {
            return View();
        }
        public IActionResult GetStarted()
        {
            return View();
        }
        public IActionResult Signin()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
