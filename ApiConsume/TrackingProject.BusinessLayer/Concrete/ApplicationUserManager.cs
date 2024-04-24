using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DtoLayer.Dtos.ApplicationUserDto;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Concrete
{
    public class ApplicationUserManager : IApplicationUserService
    {
        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;
        private IApplicationUserDal _applicationUserDal;

        private IConfiguration _configuration;

        public ApplicationUserManager(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IApplicationUserDal applicationUserDal, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationUserDal = applicationUserDal;
            _configuration = configuration;
        }

        public async Task<ApplicationUserManagerResponse> LoginUserAsync(LoginApplicationUserDto model)
        {
            // Kullanıcıyı e-posta adresine göre bul
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Kullanıcı bulunamazsa hata döndür
                return new ApplicationUserManagerResponse
                {
                    Message = "There is no user with that email address",
                    IsSuccess = false
                };
            }

            // Kullanıcının parolasını doğrula
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Giriş başarılı ise başarılı yanıt döndür
                return new ApplicationUserManagerResponse
                {
                    IsSuccess = true
                };
            }
            else
            {
                // Parola doğrulaması başarısız ise hata döndür
                return new ApplicationUserManagerResponse
                {
                    Message = "Invalid password",
                    IsSuccess = false
                };
            }
        }

        public async Task<ApplicationUserManagerResponse> RegisterUserAsync(CreateApplicationUserDto model)
        {
            if (model == null)
                throw new NullReferenceException("Register model is null");

            if (model.Password != model.ConfirmPassword)
            {
                ApplicationUserManagerResponse employeeManagerResponse1 = new ApplicationUserManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };
            }

            var identityuser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email= model.Mail,
                UserName = model.Mail,
            };

            var result = await _userManager.CreateAsync(identityuser, model.Password);
            if (result.Succeeded)
            {
                //this section is added to assign default role to the user when a new user is created
                if (identityuser.UserName == "ahmetseyyitkse@mail.com")
                {
                    await _userManager.AddToRoleAsync(identityuser, "Admin");
                }
                else
                {
                    await _userManager.AddToRoleAsync(identityuser, "Employee");
                }
                //await _userManager.AddToRoleAsync(identityuser, "Employee");

                return new ApplicationUserManagerResponse
                {
                    Message = "Employee created successfully!",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
            return new ApplicationUserManagerResponse
            {
                Message = "Employee did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public void TDelete(ApplicationUser entity)
        {
            _userManager.DeleteAsync(entity);
        }

        public ApplicationUser TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> TGetList()
        {
            return _applicationUserDal.GetList();
        }

        public void TInsert(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
