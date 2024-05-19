using Microsoft.EntityFrameworkCore;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Concrete
{
    public class AlertManager : IAlertService
    {
        private readonly IAlertDal _alertDal;
        private readonly Context _dbContext;

        public AlertManager(IAlertDal alertDal, Context dbContext)
        {
            _alertDal = alertDal;
            _dbContext = dbContext;
        }

        public List<Alert> GetAlertsByUserId(int userId)
        {
            return _dbContext.Alerts.Where(a => a.UserId == userId).ToList();
        }

        public void TDelete(Alert entity)
        {
            _alertDal.Delete(entity);
        }

        public Alert TGetById(int id)
        {
            return _alertDal.GetById(id);
        }

        public List<Alert> TGetList()
        {
            return _alertDal.GetList();
        }

        public void TInsert(Alert entity)
        {
            _alertDal.Insert(entity);
        }

        public void TUpdate(Alert entity)
        {
            _alertDal.Update(entity);
        }
    }
}
