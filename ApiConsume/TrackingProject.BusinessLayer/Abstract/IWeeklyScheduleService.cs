using TrackingProject.DtoLayer.Dtos.ApplicationUserDto;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Abstract
{
    public interface IWeeklyScheduleService : IGenericService<WeeklySchedule>
    {
        Task<List<WeeklySchedule>> GetScheduleByUserId(int id);
    }
}
