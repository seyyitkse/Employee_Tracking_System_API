using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DtoLayer.Dtos.EmployeeDto;
using TrackingProject.EntityLayer.Concrete;
using TrackingProject.WebApi.Jwt;

namespace TrackingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IEmployeeService _employeeService;
        private readonly UserManager<IdentityUser > _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(IEmployeeService employeeService, UserManager<IdentityUser> userManager,IConfiguration configuration)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _configuration = configuration;
        }


        //[HttpPost("Register")]
        //public async Task<IActionResult> RegisterAsync([FromBody]CreateEmployeeDto model)
        //{
        //    if (ModelState.IsValid) 
        //    {
        //        var result=await _employeeService.RegisterUserAsync(model);
        //        if (result.IsSuccess)
        //        {
        //            return Ok(result);
        //        }
        //        return BadRequest(result);
        //    }
        //    return BadRequest("Some properties are not valid");
        //}
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    // Yeni kullanıcı başarıyla kaydedildiğinde varsayılan rol atanması
                    var user = await _userManager.FindByNameAsync(model.Email);
                    if (user != null)
                    {
                        // Varsayılan rolü eklemek için rol adını kullanabilirsiniz
                        var roleName = "Employee";

                        // Kullanıcıya rolü atama
                        var roleResult = await _userManager.AddToRoleAsync(user, roleName);
                        if (!roleResult.Succeeded)
                        {
                            // Rol atama başarısız ise uygun bir işlem yapılabilir
                            return BadRequest("Failed to assign default role to the user.");
                        }
                    }
                    else
                    {
                        // Kullanıcı bulunamazsa uygun bir işlem yapılabilir
                        return BadRequest("User not found after registration.");
                    }

                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _employeeService.LoginUserAsync(model);
                if (user.IsSuccess)
                {
                    var token = CreateToken(model);
                    return Ok(new {Token=token});
                }
                return BadRequest(user);
            }
            return BadRequest("Some properties are not valid");
        }
        private string CreateToken(LoginEmployeeDto user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Token"]));
            List<Claim> claims = new List<Claim>();
            {
                new Claim(ClaimTypes.Email, user.Email);
            };
            var token = new JwtSecurityToken(
                               issuer: _configuration["AuthSettings:Issuer"],
                               audience: _configuration["AuthSettings:Audience"],
                               claims: claims,
                               expires: DateTime.Now.AddDays(30),
                               notBefore: DateTime.Now,
                               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenAsString;
        }
    }
}

