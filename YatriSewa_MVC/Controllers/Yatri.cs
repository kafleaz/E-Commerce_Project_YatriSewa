using Microsoft.AspNetCore.Mvc;
using YatriSewa_MVC.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

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
        //public IActionResult Signup()
        //{
        //    return View();
        //}
        public IActionResult Changepassword()
        {
            return View();
        }
        public IActionResult Busdetails()
        {
            return View();
        }
        public IActionResult Customerfeedback()
        {
            return View();
        }
        public IActionResult Giftcard()
        {
            return View();
        }
        public IActionResult Myticket()
        {
            return View();
        }
        public IActionResult Notavailable()
        {
            return View();
        }
        public IActionResult Notification()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult Paymentcard()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Selectseat()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }


        private readonly UserContext _context;

        //public UserContext Context => _context;

        public Yatri(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Passwords do not match");
                    return View(model);
                }

                model.ConfirmPassword = model.Password;
                // Process the signup information (e.g., save to database)
                // Redirect to a success page or perform other actions
                var user = new LoginUser
                {
                    Email = model.Email,
                    Password = model.Password
                };

                // Save user to database
                _context.UserLogin.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Home");
            }

            // If ModelState is not valid, return the view with validation errors
            //ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again later.");
            return View(model);
        }


        //[HttpPost]
        //public IActionResult Signup(LoginUser model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Login_Detail.Add(model);
        //        _context.SaveChanges();
        //        return RedirectToAction("Home");
        //    }
        //    // If ModelState is not valid, return to the signup view with validation errors.
        //    return View("Signup", model);
        //}
    }
}
