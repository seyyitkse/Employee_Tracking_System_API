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
    public class PanelUserManager : IPanelUserService
    {
        IPanelUserDal _panelUserDal;

        public PanelUserManager(IPanelUserDal adminDal)
        {
            _panelUserDal = adminDal;
        }

        public void TDelete(PanelUser entity)
        {
            _panelUserDal.Delete(entity);
        }

        public PanelUser TGetById(int id)
        {
            return _panelUserDal.GetById(id);
        }

        public List<PanelUser> TGetList()
        {
            return _panelUserDal.GetList();
        }

        public void TInsert(PanelUser entity)
        {
            _panelUserDal.Insert(entity);
        }

        public void TUpdate(PanelUser entity)
        {
            _panelUserDal.Update(entity);
        }
    }
}
