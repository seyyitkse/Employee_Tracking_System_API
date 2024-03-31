using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.WebUI.Areas.Admin.Models.ViewModels.AdminLoginTest;

namespace TrackingProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminAccountController : Controller
    {
        private readonly SignInManager<AdminLoginTest> _signInManager;

        public AdminAccountController(SignInManager<AdminLoginTest> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> SignInAsync(AdminLoginTest adminLogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(adminLogin.Username, adminLogin.Password, true, true);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Login", "AdminAccount");
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz parola ya da kullanıcı adı");
                }

            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
