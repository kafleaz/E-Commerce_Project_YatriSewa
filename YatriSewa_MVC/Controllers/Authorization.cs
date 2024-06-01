//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using YatriSewa_MVC.Models;

//[Authorize]
//public class AccountController : Controller
//{
//    private readonly UserContext _context;
//    private readonly UserManager<ApplicationUser> _userManager;
//    private readonly SignInManager<ApplicationUser> _signInManager;

//    public AccountController(UserContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
//    {
//        _context = context;
//        _userManager = userManager;
//        _signInManager = signInManager;
//    }

//    [AllowAnonymous]
//    public IActionResult Signup()
//    {
//        return View();
//    }

//    [HttpPost]
//    [AllowAnonymous]
//    public async Task<IActionResult> Signup(LoginUser model)
//    {
//        if (ModelState.IsValid)
//        {
//            var existingUser = await _userManager.FindByEmailAsync(model.Email);
//            if (existingUser != null)
//            {
//                ModelState.AddModelError("Email", "Account already exists. Please Go Back & sign in.");
//                return View(model);
//            }

//            if (model.Password != model.ConfirmPassword)
//            {
//                ModelState.AddModelError("ConfirmPassword", "Passwords do not match");
//                return View(model);
//            }

//            var user = new ApplicationUser
//            {
//                UserName = model.Email,
//                Email = model.Email
//            };

//            var result = await _userManager.CreateAsync(user, model.Password);
//            if (result.Succeeded)
//            {
//                // Optionally add user to a role here
//                await _userManager.AddToRoleAsync(user, "UserRole");

//                await _signInManager.SignInAsync(user, isPersistent: false);
//                return RedirectToAction("Register", "Yatri", new { userLoginId = user.Id });
//            }

//            foreach (var error in result.Errors)
//            {
//                ModelState.AddModelError(string.Empty, error.Description);
//            }
//        }

//        return View(model);
//    }
//}
