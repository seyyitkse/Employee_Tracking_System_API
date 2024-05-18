using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.DataAccessLayer.Repositories;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.DataAccessLayer.EntityFramework
{
    public class EFAlertDal : GenericRepository<Alert>, IAlertDal
    {
        public EFAlertDal(Context context) : base(context)
        {
        }
    }
}
