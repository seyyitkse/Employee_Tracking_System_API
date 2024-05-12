using TrackingProject.DtoLayer.Dtos.ApplicationUserDto;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Abstract
{
    public interface IApplicationUserService:IGenericService<ApplicationUser>
    {
        Task<ApplicationUserManagerResponse> RegisterUserAsync(CreateApplicationUserDto model);
        Task<ApplicationUserManagerResponse> LoginUserAsync(LoginApplicationUserDto model);
        Task<ApplicationUserManagerResponse> MobileLoginAsync(LoginApplicationUserDto model);
    }
}
