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
    public class ScheduleTypeManager : IScheduleTypeService
    {
        private readonly IScheduleTypeDal _scheduleType;

        public ScheduleTypeManager(IScheduleTypeDal scheduleType)
        {
            _scheduleType = scheduleType;
        }

        public void TDelete(ScheduleType entity)
        {
            _scheduleType.Delete(entity);
        }

        public ScheduleType TGetById(int id)
        {
            return _scheduleType.GetById(id);
        }

        public List<ScheduleType> TGetList()
        {
            return _scheduleType.GetList();
        }

        public void TInsert(ScheduleType entity)
        {
            _scheduleType.Insert(entity);
        }

        public void TUpdate(ScheduleType entity)
        {
            _scheduleType.Update(entity);
        }
    }
}
