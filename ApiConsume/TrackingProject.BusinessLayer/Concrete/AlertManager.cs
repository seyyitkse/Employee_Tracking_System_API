using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Concrete
{
    public class AlertManager : IAlertService
    {
        IAlertDal _alertDal;

        public AlertManager(IAlertDal alertDal)
        {
            _alertDal = alertDal;
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
