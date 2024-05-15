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
        //public IActionResult Signin()
        //{
        //    return View();
        //}
        //public IActionResult Signup()
        //{
        //    return View();
        //}
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
                var existingUser = _context.UserLogin.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Account already exists. Please Go Back $ sign in.");
                    return View(model);
                }

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
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword
                };

                // Save user to database
                _context.UserLogin.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Register");
            }

            // If ModelState is not valid, return the view with validation errors
            //ModelState.AddModelError(string.Empty, "An error occurred while processing your request. Please try again later.");
            return View(model);
        }





        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(LogUser model)
        {
            if (ModelState.IsValid)
            {
                // Authenticate the user
                var user = _context.UserLogin.FirstOrDefault(u => u.Email == model.Email);

                if (user == null)
                {
                    // Email not found
                    ModelState.AddModelError("Email", "User not found. Please Sign up first.");
                    return View(model);
                }

                if (user.Password != model.Password)
                {
                    // Incorrect password
                    ModelState.AddModelError("Password", "Incorrect password.");
                    return View(model);
                }

                return RedirectToAction("Home");
            
            }

            // If ModelState is not valid, return to the sign-in view with validation errors.
            return View(model);
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.UserLogin.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser == null)
                {
                    // User not found, show appropriate message
                    ModelState.AddModelError("Email", "No user found with this email address.");
                    return View(model);
                }

                if (model.NewPassword != model.ConfirmNewPassword)
                {
                    // Password and confirm password do not match, show appropriate message
                    ModelState.AddModelError("ConfirmNewPassword", "Passwords do not match.");
                    return View(model);
                }

                // Update the user's password and confirm password
                existingUser.Password = model.NewPassword;
                existingUser.ConfirmPassword = model.ConfirmNewPassword;

                // Save changes to the database
                _context.SaveChanges();

                // Redirect the user to a page informing them that their password has been updated
                return RedirectToAction("Signin");
            }

            // If ModelState is not valid, return the view with validation errors
            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer model)
        {
            if (ModelState.IsValid)
            {

                var user = new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age
                };
                // Add customer to database
                _context.Customers.Add(model);
                _context.SaveChanges();

                // Redirect to sign-in page
                return RedirectToAction("Signin");
            }
            return View(model);
        }




    }

}
