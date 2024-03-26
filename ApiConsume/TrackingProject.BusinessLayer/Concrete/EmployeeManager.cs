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
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void TDelete(Employee entity)
        {
            _employeeDal.Delete(entity);
        }

        public Employee TGetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public List<Employee> TGetList()
        {
            return _employeeDal.GetList();
        }

        public void TInsert(Employee entity)
        {
            _employeeDal.Insert(entity);
        }

        public void TUpdate(Employee entity)
        {
            _employeeDal.Update(entity);
        }
    }
}
