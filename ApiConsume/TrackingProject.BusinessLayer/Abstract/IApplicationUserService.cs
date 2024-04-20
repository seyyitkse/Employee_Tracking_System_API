using TrackingProject.DtoLayer.Dtos.ApplicationUserDto;

namespace TrackingProject.BusinessLayer.Abstract
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserManagerResponse> RegisterUserAsync(CreateApplicationUserDto model);
        Task<ApplicationUserManagerResponse> LoginUserAsync(LoginApplicationUserDto model);
    }
}
