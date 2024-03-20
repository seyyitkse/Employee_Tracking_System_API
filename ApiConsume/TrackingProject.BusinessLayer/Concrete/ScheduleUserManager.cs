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
    public class ScheduleUserManager : IScheduleUserService
    {
        private readonly IScheduleUserDal _scheduleUser;

        public ScheduleUserManager(IScheduleUserDal scheduleUser)
        {
            _scheduleUser = scheduleUser;
        }

        public void TDelete(ScheduleUser entity)
        {
            _scheduleUser.Delete(entity);
        }

        public ScheduleUser TGetById(int id)
        {
            return _scheduleUser.GetById(id);
        }

        public List<ScheduleUser> TGetList()
        {
            return _scheduleUser.GetList();
        }

        public void TInsert(ScheduleUser entity)
        {
            _scheduleUser.Insert(entity);
        }

        public void TUpdate(ScheduleUser entity)
        {
            _scheduleUser.Update(entity);
        }
    }
}
