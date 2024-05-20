using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.DtoLayer.Dtos.ApplicationUserDto;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IApplicationUserService _applicationUserService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly Context _context;

        public AuthController(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager, IConfiguration configuration,RoleManager<ApplicationRole> roleManager)
        {
            _roleManager= roleManager;
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost("RegisterEmployee")]
        public async Task<IActionResult> RegisterEmployeeAsync([FromBody] CreateApplicationUserDto model)
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
        public async Task<IActionResult> RegisterAdminAsync([FromBody] CreateApplicationUserDto model)
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
                    var token = CreateToken(model);
                    return Ok(new { Token = token });
                }
                return BadRequest(user);
            }
            return BadRequest("Some properties are not valid");
        }
        //[HttpPost("mobileLogin")]
        //public async Task<IActionResult> MobileLoginAsync([FromBody] LoginApplicationUserDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _applicationUserService.MobileLoginAsync(model);
        //        if (response.IsSuccess)
        //        {
        //            return Ok(new {response.Message });
        //        }
        //        return BadRequest(response);
        //    }
        //    return BadRequest("Some properties are not valid");
        //}
        [HttpPost("mobileLogin")]
        public async Task<IActionResult> MobileLoginAsync([FromBody] LoginApplicationUserDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _applicationUserService.MobileLoginAsync(model);
                if (response.IsSuccess)
                {
                    return Ok(new { response.Message });
                }
                return BadRequest(response);
            }
            return BadRequest("Some properties are not valid");
        }
        [HttpPost("mobileLogout")]
        public async Task<IActionResult> LogoutAsync([FromBody] LogoutApplicationUserDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _applicationUserService.MobileLogoutAsync(model.Email);
                if (response.IsSuccess)
                {
                    return Ok(new { Message = response.Message });
                }
                return BadRequest(response);
            }
            return BadRequest("Some properties are not valid");
        }
        private string CreateToken(LoginApplicationUserDto user)
        {
            //kullanıcı ad - soyad,departman adı,giriş çıkış saatleri, eklenecek
            //Kullanıcının rollerini veri tabanından alıyoruz
            ApplicationUser userRole = _userManager.Users.FirstOrDefault(x => x.Email == user.Email);
            var roleNames = _userManager.GetRolesAsync(userRole).Result;
            string joinRoleName = string.Join(',', roleNames);
            string name = userRole.FirstName+" "+userRole.LastName;
            //int departmentId = userRole.DepartmentID;
            // department = _context.Departments.FirstOrDefault(d => d.DepartmentID == departmentId);
            //var departmentName = department != null ? department.Name : "";
            int userID = userRole.Id;
            // Token için gerekli anahtar oluşturuyoruz
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Token"]));
            
            // Token içereceği iddia edilen (claims) bilgileri belirliyoruz
            var claims = new List<Claim>
            {
                new Claim("Mail", user.Email),
                new Claim("Username", userRole.UserName),
                new Claim("Name", name),
                new Claim("Role", joinRoleName),
                //new Claim("Department", departmentName),
                new Claim("UserID", userID.ToString())
            };

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
        //public async Task<List<UserLoginHistory>> GetUserLoginHistory(string userId)
        //{
        //    return await _context.UserLoginHistory
        //        .Where(x => x.UserId == userId)
        //        .OrderByDescending(x => x.LoginTime)
        //        .ToListAsync();
        //}
        // 1. Enable 2FA for the user
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        await _userManager.SetTwoFactorEnabledAsync(user, true);

        //        // 2. Generate a 2FA token
        //        var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

        //        // 3. Send the 2FA token to the user
        //        // This will depend on your method of communication, but here's a basic example for email:
        //        await _emailSender.SendEmailAsync(user.Email, "Your authentication code", $"Your two-factor authentication code is: {token}");

        //        // 4. Verify the 2FA token provided by the user
        //        var is2faTokenValid = await _userManager.VerifyTwoFactorTokenAsync(user, "Email", model.Token);
        //if (!is2faTokenValid)
        //{
        //    return BadRequest("Invalid token.");
        //    }

        //    // Continue with sign in...
    }
}

