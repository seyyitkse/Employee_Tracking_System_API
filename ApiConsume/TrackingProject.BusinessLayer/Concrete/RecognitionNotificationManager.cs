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
    public class RecognitionNotificationManager : IRecognitionNotificationService
    {
        private readonly IRecognitionNotificationDal _recognitionNotification;

        public RecognitionNotificationManager(IRecognitionNotificationDal recognitionNotification)
        {
            _recognitionNotification = recognitionNotification;
        }

        public void TDelete(RecognitionNotification entity)
        {
            _recognitionNotification.Delete(entity);
        }

        public RecognitionNotification TGetById(int id)
        {
            return _recognitionNotification.GetById(id);
        }

        public List<RecognitionNotification> TGetList()
        {
            return _recognitionNotification.GetList();
        }

        public void TInsert(RecognitionNotification entity)
        {
            _recognitionNotification.Insert(entity);
        }

        public void TUpdate(RecognitionNotification entity)
        {
            _recognitionNotification.Update(entity);
        }
    }
}
