using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;


namespace TrackingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAccountController : ControllerBase
    {
        //private readonly SignInManager<PanelUser> _signInManager;
        //private readonly IConfiguration _configuration;
        //private readonly UserManager<PanelUser> _userManager;

        //public AdminAccountController(UserManager<PanelUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //public AdminAccountController(SignInManager<PanelUser> signInManager, IConfiguration config)
        //{
        //    _signInManager = signInManager;
        //    _configuration = config;
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] AdminLoginViewModel model)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);
        //    if (result.Succeeded)
        //    {
        //        return Ok("Giriş başarılı.");
        //    }
        //    else
        //    {
        //        return BadRequest("Kullanıcı adı veya parola yanlış.");
        //    }
        //}
        //[HttpPost("register")]
        //public async Task<IActionResult> Register( AdminRegisterViewModel model)
        //{
        //    var user = new PanelUser { UserName = model.Username, Email = model.Email };
        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (result.Succeeded)
        //    {
        //        await _signInManager.SignInAsync(user, isPersistent: false);
        //        return Ok("Kayıt başarılı.");
        //    }
        //    else
        //    {
        //        return BadRequest(result.Errors.FirstOrDefault()?.Description);
        //    }
        //}
    }
}
