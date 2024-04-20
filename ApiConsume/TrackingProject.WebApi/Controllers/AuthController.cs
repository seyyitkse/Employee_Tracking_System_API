using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DtoLayer.Dtos.ApplicationUserDto;
using TrackingProject.DtoLayer.Dtos.EmployeeDto;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IApplicationUserService _applicationUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateApplicationUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationUserService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }
        //[HttpPost("Login")]
        //public async Task<IActionResult> LoginAsync([FromBody] LoginApplicationUserDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _applicationUserService.LoginUserAsync(model);
        //        if (user.IsSuccess)
        //        {
        //            var token = CreateToken(model);
        //            return Ok(new {Token=token});
        //        }
        //        return BadRequest(user);
        //    }
        //    return BadRequest("Some properties are not valid");
        //}
        //private string CreateToken(LoginApplicationUserDto user)
        //{
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Token"]));
        //    List<Claim> claims = new List<Claim>();
        //    {
        //        new Claim(ClaimTypes.Email, user.Email);
        //    };
        //    var token = new JwtSecurityToken(
        //                       issuer: _configuration["AuthSettings:Issuer"],
        //                       audience: _configuration["AuthSettings:Audience"],
        //                       claims: claims,
        //                       expires: DateTime.Now.AddDays(30),
        //                       notBefore: DateTime.Now,
        //                       signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        //    var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
        //    return tokenAsString;
        //}
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginApplicationUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _applicationUserService.LoginUserAsync(model);
                if (user.IsSuccess)
                {
                    // Kullanıcı başarılı bir şekilde giriş yaptıysa JWT oluştur
                    var token = CreateToken(model.Email);
                    return Ok(new { Token = token });
                }
                return BadRequest(user);
            }
            return BadRequest("Some properties are not valid");
        }

        private string CreateToken(string userEmail)
        {
            // Token için gerekli anahtar oluşturuluyor
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Token"]));

            // Token içereceği iddia edilen (claims) bilgileri belirleniyor
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Email, userEmail)
    };

            // Token'in oluşturulma ve geçerlilik süreleri belirleniyor
            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30), // Token'in geçerlilik süresi
                notBefore: DateTime.UtcNow, // Token'in ne zaman geçerli olacağı
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // Oluşturulan token string olarak dönüştürülüyor
            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenAsString;
        }
    }
}

