using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DtoLayer.Dtos.EmployeeDto;

namespace TrackingProject.BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private UserManager<IdentityUser> _userManager;

        private SignInManager<IdentityUser> _signInManager;

        private IConfiguration _configuration;
        public EmployeeManager(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<EmployeeManagerResponse> LoginUserAsync(LoginEmployeeDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new EmployeeManagerResponse
                {
                    Message = "There is no user with that email address",
                    IsSuccess = false,
                };
            }
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                return new EmployeeManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false,
                };
            }

            var claim = new[]
            {
                new Claim("Email",model.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
            };

            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                               issuer: _configuration["AuthSettings:Issuer"],
                               audience: _configuration["AuthSettings:Audience"],
                               claims: claim,
                               expires: DateTime.Now.AddDays(30),
                               notBefore: DateTime.Now,
                               signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new EmployeeManagerResponse
            {
                Message = tokenString,
                IsSuccess = true,
                ExpireDate=token.ValidTo,
            };
        }

        public async Task<EmployeeManagerResponse> RegisterUserAsync(CreateEmployeeDto model)
        {
            if (model == null)
                throw new NullReferenceException("Register model is null");

            if (model.Password != model.ConfirmPassword)
            {
                EmployeeManagerResponse employeeManagerResponse1 = new EmployeeManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };
            }

            var identityuser = new IdentityUser()
            {
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await _userManager.CreateAsync(identityuser, model.Password);
            if (result.Succeeded)
            {
                return new EmployeeManagerResponse
                {
                    Message = "Employee created successfully!",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
            return new EmployeeManagerResponse
            {
                Message = "Employee did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}
