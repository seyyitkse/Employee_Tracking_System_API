using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.DataAccessLayer.Repositories;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.DataAccessLayer.EntityFramework
{
    public class EFRFIDExampleDal : GenericRepository<RFIDExample>, IRFIDExampleDal
    {
        public EFRFIDExampleDal(Context context) : base(context)
        {
        }
    }
}
