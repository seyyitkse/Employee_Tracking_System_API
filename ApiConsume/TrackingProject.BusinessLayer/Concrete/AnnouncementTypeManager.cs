using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Concrete
{
    public class AnnouncementTypeManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementType;

        public AnnouncementTypeManager(IAnnouncementDal announcementType)
        {
            _announcementType = announcementType;
        }

        public void TDelete(Announcement entity)
        {
            _announcementType.Delete(entity);
        }

        public Announcement TGetById(int id)
        {
            return _announcementType.GetById(id);
        }

        public List<Announcement> TGetList()
        {
            return _announcementType.GetList();
        }

        public void TInsert(Announcement entity)
        {
            _announcementType.Insert(entity);
        }

        public void TUpdate(Announcement entity)
        {
            _announcementType.Update(entity);
        }
    }
}
