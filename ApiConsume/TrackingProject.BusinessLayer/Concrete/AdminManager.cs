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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TDelete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public Admin TGetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public List<Admin> TGetList()
        {
            return _adminDal.GetList();
        }

        public void TInsert(Admin entity)
        {
            _adminDal.Insert(entity);
        }

        public void TUpdate(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
