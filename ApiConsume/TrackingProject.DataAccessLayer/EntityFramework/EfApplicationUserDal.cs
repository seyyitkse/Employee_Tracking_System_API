using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.DataAccessLayer.Repositories;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.DataAccessLayer.EntityFramework
{
    public class EfApplicationUserDal : GenericRepository<ApplicationUser>, IApplicationUserDal
    {
        public EfApplicationUserDal(Context context) : base(context)
        {
        }
    }
}
