using AutoMapper;
using HMH.core.Interfaces;
using HMH.Core.Services;
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
        private readonly IMapper _mapper;
        private readonly IimageserviceMangment _iimageserviceMangment;
        public IDoctorRepository doctorRepository { get; }

        public IDoctorScheduleRepository doctorScheduleRepository { get; }

        public IAppointmentsRepository appointmentsRepository { get; }

        public IRatingRepository ratingRepository { get; }

        public IClinicsRepository clinicsRepository { get; }

        public INotificationRepository notificationRepository { get; }

        public IOfferRepository offerRepository { get; }


        public UnitOfWork(AppDbContext context, IMapper mapper, IimageserviceMangment iimageserviceMangment )
        {
            this._context = context;
            _mapper = mapper;
            _iimageserviceMangment = iimageserviceMangment;
            doctorRepository = new DoctorRepository(context, _mapper, iimageserviceMangment);
            doctorScheduleRepository = new DoctorScheduleRepository(context);
            appointmentsRepository = new AppointmentsRepository(context);
            ratingRepository = new RatingRepository(context);
            clinicsRepository = new ClinicsRepository(context, _mapper, _iimageserviceMangment);
            notificationRepository = new NotificationRepository(context);
            offerRepository = new OfferRepository(context);
           
        }
    }
}
