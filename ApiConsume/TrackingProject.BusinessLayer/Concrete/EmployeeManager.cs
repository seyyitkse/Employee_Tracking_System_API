using Microsoft.AspNetCore.Identity;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DtoLayer.Dtos.EmployeeDto;

namespace TrackingProject.BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private UserManager<IdentityUser> _userManager;

        public EmployeeManager(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        private SignInManager<IdentityUser> _signInManager;

        public EmployeeManager(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<EmployeeManagerResponse> LoginUserAsync(LoginEmployeeDto model)
        {
            if (model !=null)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, true);
                if (result.Succeeded)
                {
                    EmployeeManagerResponse employeeManagerResponse = new EmployeeManagerResponse()
                    {
                        Message = "Login successfully!",
                    };
                }
            }
            return new EmployeeManagerResponse
            {
                Message = "Login problem!!!",
                IsSuccess = false,
                //Errors = res.Errors.Select(e => e.Description)
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
