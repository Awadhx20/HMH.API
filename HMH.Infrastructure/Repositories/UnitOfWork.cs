using AutoMapper;
using HMH.core.Interfaces;
using HMH.Core.Entites;
using HMH.Core.Interfaces;
using HMH.Core.Services;
using HMH.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService  _emailService;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly IMapper _mapper;
        private readonly IimageserviceMangment _iimageserviceMangment;
        private readonly IGenerateToken token;
        public IDoctorRepository doctorRepository { get; }

        public IDoctorScheduleRepository doctorScheduleRepository { get; }

        public IAppointmentsRepository appointmentsRepository { get; }

        public IRatingRepository ratingRepository { get; }

        public IClinicsRepository clinicsRepository { get; }

        public INotificationRepository notificationRepository { get; }

        public IOfferRepository offerRepository { get; }

        public IAuth Auth { get;  }

        public UnitOfWork(AppDbContext context, IMapper mapper, IimageserviceMangment iimageserviceMangment, UserManager<ApplicationUser> userManager, IEmailService emailService, SignInManager<ApplicationUser> signInManger, IGenerateToken token)
        {
            this._context = context;
            _mapper = mapper;
            _iimageserviceMangment = iimageserviceMangment;
            _userManager = userManager;
            _emailService = emailService;
            _signInManger = signInManger;
            this.token = token;
            doctorRepository = new DoctorRepository(context, _mapper, iimageserviceMangment);
            doctorScheduleRepository = new DoctorScheduleRepository(context);
            appointmentsRepository = new AppointmentsRepository(context);
            ratingRepository = new RatingRepository(context);
            clinicsRepository = new ClinicsRepository(context, _mapper, _iimageserviceMangment);
            notificationRepository = new NotificationRepository(context);
            offerRepository = new OfferRepository(context);
            Auth = new AuthRepository(userManager, emailService, signInManger, token);
        }
    }
}
