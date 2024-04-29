using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;
        private readonly Context _context;

        public UserImageManager(IUserImageDal userImageDal, Context context)
        {
            _userImageDal = userImageDal;
            _context = context;
        }

        public async Task AddUserImageAsync(int userId, byte[] imageData, string imageMimeType)
        {
            var userImage = new UserProfileImage
            {
                EmployeeID = userId,
                ImageData = imageData,
                ImageMimeType = imageMimeType
            };

            _context.UserImages.Add(userImage);
            await _context.SaveChangesAsync();
        }

        public void TDelete(UserProfileImage entity)
        {
            throw new NotImplementedException();
        }

        public UserProfileImage TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserProfileImage> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(UserProfileImage entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(UserProfileImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
