using Microsoft.AspNetCore.Mvc;
using YatriSewa_MVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        public IActionResult Selectseat()
        {
            return View();
        }
        public IActionResult Error()
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

                var userLoginId = user.Login_ID;

                return RedirectToAction("Register", "Yatri", new { userLoginId });
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

                var userLoginId = user.Login_ID;
                return RedirectToAction("Home", new { userLoginId });

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
        public IActionResult Register(int? userLoginId)
        {
            if (!userLoginId.HasValue)
            {
                // Handle the case when userLoginId is not provided
                return RedirectToAction("Signup");
            }

            // Pass the userLoginId to the view
            ViewBag.UserLoginId = userLoginId.Value;
            return View();
        }




        [HttpPost]
        public IActionResult Register(Customer customer, int userLoginId)
        {

            if (ModelState.IsValid)
            {

                var userLogin = _context.UserLogin.FirstOrDefault(u => u.Login_ID == userLoginId);

                if (userLogin == null)
                {
                    // Handle the case when userLoginId is invalid
                    ModelState.AddModelError(string.Empty, "Invalid User Login ID.");
                    return View(customer);
                }


                var customers = new Customer
                {

                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Gender = customer.Gender,
                    Age = customer.Age,
                    ContactNo = customer.ContactNo,
                    District = customer.District,
                    City = customer.City,
                    //Login_ID = userLoginId // Use the Login_ID property from the model
                };
                customer.Login_ID = userLoginId;

                // Add customer to database
                _context.Customers.Add(customer);
                _context.SaveChanges();

                // Redirect to sign-in page
                return RedirectToAction("Signin");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Home(int? userLoginId)
        {
            if (userLoginId.HasValue)
            {
                ViewBag.UserLoginId = userLoginId.Value;
                // Handle the case when userLoginId is not provided

            }           
           // Pass the userLoginId to the view
           return View();
        }

        [HttpPost]
        public IActionResult Home(int userLoginId)
        {
            //if (userLoginId.HasValue)
            //{
            //    ViewBag.UserLoginId = userLoginId.Value;
                // Handle the case when userLoginId is not provided         
               // Optionally handle the case where userLoginId is not provided
                // Redirect to a default action or show a message
                return RedirectToAction("Signin", "Yatri", new { userLoginId });
            

            //// Pass the userLoginId to the view

            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int userLoginId)
        {
            // Fetch customer data
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Login_ID == userLoginId);

            // Fetch login user data
            var loginUser = await _context.UserLogin
                .FirstOrDefaultAsync(l => l.Login_ID == userLoginId);

            if (customer == null || loginUser == null)
            {
                return NotFound();
            }

            // Populate the ViewModel
            var profileViewModel = new ProfileViewModel
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Age = customer.Age,
                ContactNo = customer.ContactNo,
                City = customer.City,
                District = customer.District,
                Gender = customer.Gender, // Convert Gender int to string
                Email = loginUser.Email, // Set the email from LoginUser table
            };

            return View(profileViewModel);
        }


        public IActionResult ProfileEdit()
        {
            return View();
        }





    }



}

