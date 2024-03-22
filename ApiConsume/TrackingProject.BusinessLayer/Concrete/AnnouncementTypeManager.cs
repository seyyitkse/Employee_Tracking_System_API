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
    public class AnnouncementTypeManager : IAnnouncementTypeService
    {
        IAnnouncementTypeDal _announcementType;

        public AnnouncementTypeManager(IAnnouncementTypeDal announcementType)
        {
            _announcementType = announcementType;
        }

        public void TDelete(AnnouncementType entity)
        {
            _announcementType.Delete(entity);
        }

        public AnnouncementType TGetById(int id)
        {
            return _announcementType.GetById(id);
        }

        public List<AnnouncementType> TGetList()
        {
            return _announcementType.GetList();
        }

        public void TInsert(AnnouncementType entity)
        {
            _announcementType.Insert(entity);
        }

        public void TUpdate(AnnouncementType entity)
        {
            _announcementType.Update(entity);
        }
    }
}
