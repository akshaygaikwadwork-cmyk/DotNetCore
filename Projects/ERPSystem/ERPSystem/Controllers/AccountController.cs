using ERPSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GoogleReCaptcha.V3.Interface;
using GoogleRecaptcha;

namespace ERPSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPasswordHasher<IdentityUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password).ConfigureAwait(true);
                if (result.Succeeded)
                    return RedirectToAction("Login","Account");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var recaptchaResponse = await _recaptcha.ValidateAsync(HttpContext);
                //if (!recaptchaResponse.success)
                //{
                //    ModelState.AddModelError("", "Please verify that you are not a robot.");
                //    return View(model);
                //}

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Dashboard");

                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult ForgotPassword() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ForgotPasswordUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    // Hash the new password
                    var passwordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                    user.PasswordHash = passwordHash;

                    // Update the user
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        // Optionally: sign in the user or redirect to a confirmation page
                        return RedirectToAction("Login");
                    }

                    // Add errors if update fails
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No user found with this email.");
                }
            }

            return View("ForgotPassword", model); // Return to the same view with validation errors
        }

        [HttpGet]
        public IActionResult ResetPassword(string token) => View(new ResetPasswordViewModel { Token = token });


        public IActionResult Dashboard() => View();

    }
}
