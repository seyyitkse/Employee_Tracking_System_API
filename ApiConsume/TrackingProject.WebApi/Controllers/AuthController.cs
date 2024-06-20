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

        public AuthController(IApplicationUserService applicationUserService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration, Context context)
        {
            _applicationUserService = applicationUserService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
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
            return Ok();
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
                    var token = await CreateTokenAsync(model);
                    return Ok(new { token });
                }
                return BadRequest(user);
            }
            return BadRequest("Some properties are not valid");
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordDto model)
        {
            if (ModelState.IsValid)
            {
                if (model.NewPassword != model.NewPassword)
                {
                    return BadRequest("New password and confirmation password do not match.");
                }

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return BadRequest("User not found.");
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    return Ok("Password changed successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
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
                    var token = await CreateTokenAsync(model);
                    return Ok(new { token, response.Message });
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
        private async Task<string> CreateTokenAsync(LoginApplicationUserDto loginUser)
        {
            ApplicationUser user = _userManager.Users.FirstOrDefault(x => x.Email == loginUser.Email);
            var roles = await _userManager.GetRolesAsync(user);

            string name = $"{user.FirstName} {user.LastName}";
            int userID = user.Id;

            int departmanId = user.DepartmentID;
            Department department = _context.Departments.FirstOrDefault(x => x.DepartmentID == departmanId);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Token"]));

            var claims = new List<Claim>
            {
                new Claim("Mail", user.Email),
                new Claim("Username", user.UserName),
                new Claim("Name", name),
                new Claim("Department", department.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserID", userID.ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                notBefore: DateTime.Now,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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

