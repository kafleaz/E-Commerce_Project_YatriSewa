using Microsoft.AspNetCore.Mvc;
using YatriSewa_MVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

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

        public IActionResult SelectSeat()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }


        private readonly UserContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Yatri(UserContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
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
            }
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Home(SearchViewModel model, int userLoginId)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine($"UserLoginId in Home POST: {userLoginId}");
                // Query the Buses table to check for a matching entry

                var busExists = await _context.Buses
                    .AnyAsync(b => b.From == model.From && b.To == model.To && b.Date == model.Date);

                if (busExists)
                {
                    
                    // Redirect to the Listing page if a match is found
                    return RedirectToAction("BusListing","Yatri", new { from = model.From, to = model.To, date = model.Date, userLoginId = userLoginId });
                }
                else
                {
                    // No matching bus found, display an appropriate message
                    return RedirectToAction("Error");
                }
            }

            // If ModelState is not valid or no bus found, reload the Home view with the userLoginId
            ViewBag.UserLoginId = userLoginId;
            //model.FromLocations = await _context.Buses.Select(b => b.From).Distinct().ToListAsync();
            //model.ToLocations = await _context.Buses.Select(b => b.To).Distinct().ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BusListing(string from, string to, DateOnly date,int userLoginId)
        {
            ViewBag.UserLoginId = userLoginId;

            var buses = await _context.Buses
                .Include(b => b.Operator)
                .Where(b => b.From == from && b.To == to && b.Date == date)
                .ToListAsync();

            ViewBag.From = from;
            ViewBag.To = to;
            ViewBag.Date = date;

            foreach (var bus in buses)
            {
                bus.Service = await _context.Services.FirstOrDefaultAsync(s => s.BusId == bus.BusId);
            }

            //ViewBag.UserLoginId = userLoginId;
            return View(buses);
        }

        [HttpGet("SelectSeat")]
        [HttpPost("SelectSeat")]
        public async Task<IActionResult> SelectSeat(int busId, int userLoginId, string from, string to, DateOnly date, string[] seats = null)
        {
            if (Request.Method == "POST")
            {
                return await BookSeats(busId, userLoginId, from, to, date, seats);
            }

            var bus = await _context.Buses.FindAsync(busId);
            if (bus == null)
            {
                return NotFound();
            }

            var seatsList = await _context.Seats.Where(s => s.BusId == busId).ToListAsync();
            var services = await _context.Services.FirstOrDefaultAsync(s => s.BusId == busId);
            var user = await _context.Customers.FindAsync(userLoginId);
            var passengers = await _context.Passengers.Where(p => p.BusId == busId).ToListAsync();

            ViewBag.BusName = bus.BusName;
            ViewBag.UserLoginId = userLoginId;
            ViewBag.From = from;
            ViewBag.To = to;
            ViewBag.Date = date;
            ViewBag.SeatCapacity = bus.SeatCapacity;
            ViewBag.Services = services;
            ViewBag.Passengers = passengers;
            ViewBag.Price = bus.Price;
            ViewBag.User = user;

            return View(seatsList);
        }

        private async Task<IActionResult> BookSeats(int busId, int userLoginId, string from, string to, DateOnly date, string[] seats)
        {
            decimal totalAmount = 0;
            string ticketNumber = GenerateTicketNumber();
            string pnrNumber = GeneratePNRNumber();

            var bus = await _context.Buses.FirstOrDefaultAsync(b => b.BusId == busId);

            if (bus == null)
            {
                return NotFound();
            }

            foreach (var seatNumber in seats)
            {
                var seat = await _context.Seats.FirstOrDefaultAsync(s => s.BusId == busId && s.SeatNumber == seatNumber);
                if (seat != null && !seat.IsSold)
                {
                    seat.IsReserved = true;
                    seat.UserId = userLoginId;
                    _context.Update(seat);

                    totalAmount += bus.Price;

                    var passenger = new Passenger
                    {
                        UserId = userLoginId,
                        BusId = busId,
                        TicketNumber = ticketNumber,
                        PNRNumber = pnrNumber,
                        AmountPaid = bus.Price,
                        SeatNumber = seatNumber
                    };
                    _context.Passengers.Add(passenger);
                }
            }

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                ViewBag.Bus = bus;
                ViewBag.User = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == userLoginId);
                ViewBag.TicketNumber = ticketNumber;
                ViewBag.PNRNumber = pnrNumber;
                ViewBag.TotalAmount = totalAmount;
                ViewBag.SeatsSelected = seats.Length;

                return RedirectToAction("Payment", new { busId, userLoginId, from, to, date });
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error processing your request. Please try again.";
                return View(seats);
            }
        }

        private string GenerateTicketNumber()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
        }

        private string GeneratePNRNumber()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6).ToUpper();
        }




        //[HttpPost]
        //public IActionResult UpdateSeatSelection(string seatNumber, bool isSelected, int userLoginId, int busId)
        //{
        //    var seat = _context.Seats.FirstOrDefault(s => s.SeatNumber == seatNumber && s.BusId == busId);

        //    if (seat != null)
        //    {
        //        if (isSelected)
        //        {
        //            seat.Status = "selected";
        //            seat.UserId = userLoginId;
        //        }
        //        else
        //        {
        //            seat.Status = "available";
        //            seat.UserId = null;
        //        }

        //        _context.SaveChanges();
        //    }

        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult ReserveSeats(int busId, int userLoginId)
        //{
        //    var selectedSeats = _context.Seats.Where(s => s.BusId == busId && s.UserId == userLoginId && s.Status == "selected").ToList();

        //    foreach (var seat in selectedSeats)
        //    {
        //        seat.Status = "reserved";
        //        seat.IsReserved = true;
        //    }

        //    _context.SaveChanges();

        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult ResetSeats(int busId, int userLoginId)
        //{
        //    var selectedSeats = _context.Seats.Where(s => s.BusId == busId && s.UserId == userLoginId && s.Status == "selected").ToList();

        //    foreach (var seat in selectedSeats)
        //    {
        //        seat.Status = "available";
        //        seat.UserId = null;
        //        seat.IsReserved = false;
        //    }

        //    _context.SaveChanges();

        //    return Ok();
        //}





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

            ViewBag.UserLoginId = userLoginId;
            return View(profileViewModel);
        }

        public IActionResult OperatorLogin()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult OperatorLogin(LoginAsOperator model)
        {
            // Hardcoded admin email and password
            var adminEmail = "yatri@gmail.com";
            var adminPassword = "yatri123"; // Ensure secure storage of passwords in real applications

            if (model.OperatorEmail == adminEmail && model.OperatorPassword == adminPassword)
            {
                // Redirect to the BusAdd page if credentials match
                return RedirectToAction("AdminHome");
            }
            else
            {
                // Handle the case where credentials do not match
                ModelState.AddModelError("OperatorPassword", "Invalid login attempt.");
                return View(model);
            }
        }

        public IActionResult AdminHome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BusAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BusAdd(BusFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save Operator
                var busOperator = new Operator
                {
                    Name = model.OperatorName,
                    ContactNo = model.OperatorContact,
                    Address = model.Address,
                    LicenseNo = model.LicenseNo,
                    IssueDate = model.IssueDate,
                    ExpiryDate = model.ExpiryDate
                };
                _context.Operators.Add(busOperator);
                await _context.SaveChangesAsync();

                // Save Bus
                var bus = new Bus
                {
                    BusName = model.BusName,
                    BusNumber = model.BusNumber,
                    From = model.From,
                    To = model.To,
                    Date = model.Date,
                    Time = model.Time,
                    SeatCapacity = model.SeatCapacity,
                    Price = model.Price,
                    Description = model.Description,
                    OperatorId = busOperator.OperatorId
                };

                if (model.Photo != null)
                {
                    var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Photo.CopyToAsync(fileStream);
                    }
                    bus.PhotoPath = "/uploads/" + uniqueFileName;
                }

                _context.Buses.Add(bus);
                await _context.SaveChangesAsync();

                // Save Service
                var service = new Service
                {
                    Wifi = model.WiFi,
                    AC = model.AC,
                    Meals = model.Meals,
                    SafetyFeatures = model.SafetyFeatures,
                    Essentials = model.Essentials,
                    Snacks = model.Snacks,
                    BusId = bus.BusId
                };

                _context.Services.Add(service);
                await _context.SaveChangesAsync();

                return RedirectToAction("AdminHome");
            }

            return View(model);
        }
    }
}


