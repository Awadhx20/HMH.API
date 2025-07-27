using HMH.core.Interfaces;
using HMH.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        public IDoctorRepository doctorRepository { get; }

        public IDoctorScheduleRepository doctorScheduleRepository { get; }

        public IAppointmentsRepository appointmentsRepository { get; }

        public IRatingRepository ratingRepository { get; }

        public IClinicsRepository clinicsRepository { get; }

        public INotificationRepository notificationRepository { get; }

        public IOfferRepository offerRepository { get; }
       

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            doctorRepository=new DoctorRepository(context);
            doctorScheduleRepository = new DoctorScheduleRepository(context);
            appointmentsRepository = new AppointmentsRepository(context);
            ratingRepository = new RatingRepository(context);
            clinicsRepository = new ClinicsRepository(context);
            notificationRepository = new NotificationRepository(context);
            offerRepository = new OfferRepository(context);
        }
    }
}
