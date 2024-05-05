using Microsoft.AspNetCore.Authorization;
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
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager, IConfiguration configuration,RoleManager<ApplicationRole> roleManager)
        {
            _roleManager= roleManager;
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost("RegisterEmployee")]
        public async Task<IActionResult> RegisterStudentAsync([FromBody] CreateApplicationUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationUserService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    var user = await _userManager.FindByEmailAsync(model.Mail);
                    await _userManager.AddToRoleAsync(user, "Employee");

                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Bazı değerler girilmedi!");
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterTeacherAsync([FromBody] CreateApplicationUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationUserService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    var user = await _userManager.FindByEmailAsync(model.Mail);
                    await _userManager.AddToRoleAsync(user, "Admin");

                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Bazı değerler girilmedi!");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginApplicationUserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _applicationUserService.LoginUserAsync(model);
                if (user.IsSuccess)
                {
                    // Kullanıcı başarılı bir şekilde giriş yaptıysa JWT oluşturuyoruz
                    var token = CreateToken(model);
                    Response.Cookies.Append("jwt", token, new CookieOptions
                    {
                        HttpOnly = true,
                    });

                    return Ok(new { Token = token });
                }
                return BadRequest(user);
            }
            return BadRequest("Some properties are not valid");
        }

        private string CreateToken(LoginApplicationUserDto user)
        {
            //Kullanıcının rollerini veri tabanından alıyoruz
            ApplicationUser userRole=_userManager.Users.FirstOrDefault(x=>x.Email==user.Email);
            var roleNames=_userManager.GetRolesAsync(userRole).Result;

            // Token için gerekli anahtar oluşturuyoruz
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Token"]));
            
            // Token içereceği iddia edilen (claims) bilgileri belirliyoruz
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
            };

            //Kullanıcının rollerini token içerisine ekliyoruz
            foreach (var item in roleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            // Token'in oluşturulma ve geçerlilik süreleri belirleniyor
            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30), // Token'in geçerlilik süresi
                notBefore: DateTime.Now, // Token'in ne zaman geçerli olacağı
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            // Oluşturulan token string olarak dönüştürülüyor
            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenAsString;
        }
    }
}

