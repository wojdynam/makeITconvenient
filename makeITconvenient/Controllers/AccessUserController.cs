using DataAccessLayer;
using makeITconvenient.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace makeITconvenient.Controllers
{
    public class AccessUserController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccessUserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {

                if (_signInManager.Context.User.IsInRole("Admin"))
                {
                     return RedirectToAction("AdminDashboard", "Dashboards");
                }
                if (_signInManager.Context.User.IsInRole("HR"))
                {
                    return RedirectToAction("HRDashboard", "Dashboards");
                }
                if (_signInManager.Context.User.IsInRole("User"))
                {
                    return RedirectToAction("UserDashboard", "Dashboards");
                }
            }
            
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied() => View();
    }
}
