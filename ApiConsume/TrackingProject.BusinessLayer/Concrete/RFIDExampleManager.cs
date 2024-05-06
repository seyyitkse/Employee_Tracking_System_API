using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DataAccessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.BusinessLayer.Concrete
{
    public class RFIDExampleManager : IRFIDExampleService
    {
        private readonly IRFIDExampleDal _rFIDExampleDal;

        public RFIDExampleManager(IRFIDExampleDal rFIDExampleDal)
        {
            _rFIDExampleDal = rFIDExampleDal;
        }

        public void TDelete(RFIDExample entity)
        {
            _rFIDExampleDal.Delete(entity);
        }

        public RFIDExample TGetById(int id)
        {
            return _rFIDExampleDal.GetById(id);
        }

        public List<RFIDExample> TGetList()
        {
            return _rFIDExampleDal.GetList();
        }

        public void TInsert(RFIDExample entity)
        {
            _rFIDExampleDal.Insert(entity);
        }

        public void TUpdate(RFIDExample entity)
        {
            _rFIDExampleDal.Update(entity);
        }
    }
}
