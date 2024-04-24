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
    public class WeeklyScheduleManager : IWeeklyScheduleService
    {
        private readonly IWeeklyScheduleDal _WeeklySchedule;

        public WeeklyScheduleManager(IWeeklyScheduleDal WeeklySchedule)
        {
            _WeeklySchedule = WeeklySchedule;
        }

        public void TDelete(WeeklySchedule entity)
        {
            _WeeklySchedule.Delete(entity);
        }

        public WeeklySchedule TGetById(int id)
        {
            return _WeeklySchedule.GetById(id);
        }

        public List<WeeklySchedule> TGetList()
        {
            return _WeeklySchedule.GetList();
        }

        public void TInsert(WeeklySchedule entity)
        {
            _WeeklySchedule.Insert(entity);
        }

        public void TUpdate(WeeklySchedule entity)
        {
            _WeeklySchedule.Update(entity);
        }
    }
}
