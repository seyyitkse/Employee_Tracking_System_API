using Microsoft.AspNetCore.Mvc;
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
    public class WeeklyScheduleManager : IWeeklyScheduleService
    {
        private readonly IWeeklyScheduleDal _WeeklySchedule;
        private readonly Context _context;

        public WeeklyScheduleManager(IWeeklyScheduleDal weeklySchedule, Context context)
        {
            _WeeklySchedule = weeklySchedule;
            _context = context;
        }

        public async Task<List<WeeklySchedule>> GetScheduleByUserId(int id)
        {
            var schedule = await _context.WeeklySchedules
                .Where(x => x.UserId == id)
                .ToListAsync();

            if (!schedule.Any())
            {
                throw new Exception("Schedule not found for the given user id.");
            }

            return schedule;
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
