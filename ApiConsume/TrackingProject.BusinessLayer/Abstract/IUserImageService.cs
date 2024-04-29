using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Abstract
{
    public interface IUserImageService : IGenericService<UserProfileImage>
    {
        public Task AddUserImageAsync(int userId, byte[] imageData, string imageMimeType);
    }
}
