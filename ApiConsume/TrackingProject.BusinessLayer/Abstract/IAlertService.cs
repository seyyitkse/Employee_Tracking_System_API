using Microsoft.EntityFrameworkCore;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Abstract
{
    public interface IAlertService:IGenericService<Alert>
    {
        public List<Alert> GetAlertsByUserId(int userId);
    }
}
