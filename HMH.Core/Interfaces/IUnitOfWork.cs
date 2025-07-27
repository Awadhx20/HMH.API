using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Interfaces
{
    public interface IUnitOfWork
    {
        public IDoctorRepository doctorRepository { get; }
        public IDoctorScheduleRepository doctorScheduleRepository { get; }
        public IAppointmentsRepository appointmentsRepository { get; }
        public IRatingRepository ratingRepository { get; }
        public IClinicsRepository clinicsRepository { get; }
        public INotificationRepository notificationRepository { get; }
        public IOfferRepository offerRepository { get; }
    }
}
    