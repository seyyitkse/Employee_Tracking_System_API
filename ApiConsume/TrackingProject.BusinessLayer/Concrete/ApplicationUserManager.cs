﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
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
                    Message = "Giriş başarılı!",
                    IsSuccess = true
                };
            }
            else
            {
                // Parola doğrulaması başarısız ise hata döndür
                return new ApplicationUserManagerResponse
                {
                    Message = "Geçersiz şifre",
                    IsSuccess = false
                };
            }
        }
        public async Task<ApplicationUserManagerResponse> MobileLoginAsync(LoginApplicationUserDto model)
        {
            // Kullanıcıyı e-posta adresine göre buluyoruz
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Kullanıcı bulunamazsa hata döndür
                return new ApplicationUserManagerResponse
                {
                    Message = "Bu maile sahip bir kullanıcı bulunamadı.",
                    IsSuccess = false
                };
            }
            //burası sonradan tekrar açılacak!
            // Kullanıcının başka bir cihazda oturum açıp açmadığını kontrol ediyoruz
            //var existingLogin = await _userManager.GetLoginsAsync(user);
            //if (existingLogin.Any())
            //{
            //    return new ApplicationUserManagerResponse
            //    {
            //        Message = "Lütfen diğer cihazdaki oturumu kapatınız",
            //        IsSuccess = false
            //    };
            //}

            // Kullanıcının parolasını doğruluyoruz
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Giriş başarılı ise AspNetUserLogins tablosuna bir giriş ekliyoruz
                //var loginEntry = new UserLoginInfo("Mobile", user.Email, "Mobile User");
                //await _userManager.AddLoginAsync(user, loginEntry);

                // Başarılı yanıt döndürüyoruz
                return new ApplicationUserManagerResponse
                {
                    Message = "Giriş başarılı",
                    IsSuccess = true
                };
            }
            else
            {
                // Parola doğrulaması başarısız ise hata döndürüyoruz
                return new ApplicationUserManagerResponse
                {
                    Message = "Geçersiz şifre",
                    IsSuccess = false
                };
            }
        }
        public async Task<ApplicationUserManagerResponse> RegisterUserAsync(CreateApplicationUserDto model)
        {
            if (model == null)
                throw new NullReferenceException("Boş veriler var");

            if (model.Password != model.ConfirmPassword)
            {
                return new ApplicationUserManagerResponse
                {
                    Message = "Girdiğiniz parolalar eşleşmiyor.",
                    IsSuccess = false,
                };
            }

            var existingUserByEmail = await _userManager.FindByEmailAsync(model.Mail);
            if (existingUserByEmail != null)
            {
                return new ApplicationUserManagerResponse
                {
                    Message = "Bu e-posta adresiyle kayıtlı bir kullanıcı zaten var.",
                    IsSuccess = false
                };
            }

            var identityuser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Mail,
                UserName = model.Mail,
                DepartmentID = model.DepartmentID,
                Fullname = model.FirstName + " " + model.LastName
            };

            var result = await _userManager.CreateAsync(identityuser, model.Password);
            if (result.Succeeded)
            {
                //await _userManager.AddToRoleAsync(identityuser, "Ogrenci");

                return new ApplicationUserManagerResponse
                {
                    Message = "Kullanıcı oluşturma işlemi başarıyla gerçekleştirildi.",
                    IsSuccess = true,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
            return new ApplicationUserManagerResponse
            {
                Message = "Kullanıcı oluşturulamadı!",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
        public async Task<ApplicationUserManagerResponse> MobileLogoutAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new ApplicationUserManagerResponse
                {
                    Message = "Bu e-posta adresine sahip bir kullanıcı bulunamadı.",
                    IsSuccess = false
                };
            }

            // Kullanıcının tüm girişlerini silmek için AspNetUserLogins tablosundan girişleri siliyoruz
            var loginInfo = await _userManager.GetLoginsAsync(user);
            foreach (var login in loginInfo)
            {
                await _userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
            }

            // Kullanıcın çıkış yapması için gerekli işlemleri yapıyoruz
            await _signInManager.SignOutAsync();

            return new ApplicationUserManagerResponse
            {
                Message = "Kullanıcı başarıyla çıkış yaptı.",
                IsSuccess = true
            };
        }

        public void TDelete(ApplicationUser entity)
        {
            _userManager.DeleteAsync(entity);
        }

        public ApplicationUser TGetById(int id)
        {
            return _applicationUserDal.GetById(id);
        }

        public List<ApplicationUser> TGetList()
        {
            return _applicationUserDal.GetList();
        }

        public void TInsert(ApplicationUser entity)
        {
            _applicationUserDal.Insert(entity);
        }

        public void TUpdate(ApplicationUser entity)
        {
            _applicationUserDal.Update(entity);
        }
    }
}
