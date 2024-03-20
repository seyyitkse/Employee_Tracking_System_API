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
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _department;

        public DepartmentManager(IDepartmentDal department)
        {
            _department = department;
        }

        public void TDelete(Department entity)
        {
            _department.Delete(entity);
        }

        public Department TGetById(int id)
        {
            return _department.GetById(id);
        }

        public List<Department> TGetList()
        {
            return _department.GetList();
        }

        public void TInsert(Department entity)
        {
            _department.Insert(entity);
        }

        public void TUpdate(Department entity)
        {
            _department.Update(entity);
        }
    }
}
