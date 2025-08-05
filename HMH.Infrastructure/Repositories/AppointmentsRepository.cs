using HMH.core.Entites;
using HMH.core.Entites.Dectors;
using HMH.core.Interfaces;
using HMH.Core.DTO;
using HMH.Core.Entites;
using HMH.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using HMH.Core.Sharing;


namespace HMH.Infrastructure.Repositories
{
    public class AppointmentsRepository : GenericRepository<Appointments>, IAppointmentsRepository
    {
        private readonly AppDbContext _context;
        public AppointmentsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OperationResult> AddAsync(int DoctorID, AddappointmentsDTO entity, string Email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (user == null)
                return OperationResult.Fail("المستخدم غير موجود.");

            var doctor = await _context.Doctors.FirstOrDefaultAsync(u => u.Id == DoctorID);
            if (doctor == null)
                return OperationResult.Fail("الطبيب غير موجود.");

            if (!IsDayExist(entity.AppointmentDate))
                return OperationResult.Fail("الطبيب لا يعمل في هذا اليوم.");

            int appointmentCount = _context.appointments
                .Count(a => a.DoctorId == DoctorID && a.AppointmentDate.Date == entity.AppointmentDate.Date);

            if (ISNumberOfAppoinemtInDayFull(entity.AppointmentDate, DoctorID, appointmentCount))
                return OperationResult.Fail("تم الوصول للحد الأقصى من المواعيد في هذا اليوم.");

            var newAppointment = new Appointments
            {
                AppointmentDate = entity.AppointmentDate,
                DoctorId = DoctorID,
                PatientName = entity.PatientName,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                Status = AppointmentStatus.Scheduled,
                TurnNumber = appointmentCount + 1,
                Notes = ""
            };

            await _context.appointments.AddAsync(newAppointment);
            await _context.SaveChangesAsync();

            return OperationResult.Ok("تمت إضافة الحجز بنجاح.");
        }

        public async Task<OperationResult> CancelAsync(int appoinmentId, string Email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (user == null)
                return OperationResult.Fail("المستخدم غير موجود.");

            var appointment = await _context.appointments.FirstOrDefaultAsync(a => a.Id == appoinmentId && a.UserId == user.Id);
            if (appointment == null)
                return OperationResult.Fail("الموعد غير موجود أو لا يخصك.");

            if (appointment.Status == AppointmentStatus.Canceled)
                return OperationResult.Fail("الموعد ملغي بالفعل.");
            if (appointment.Status == AppointmentStatus.Completed)
                return OperationResult.Fail("الموعد مكتمل ");

            appointment.Status = AppointmentStatus.Canceled;
            await _context.SaveChangesAsync();

            return OperationResult.Ok("تم إلغاء الموعد بنجاح.");

        }

        public async Task<List<appointmentsDTO>> GetAllAsync(AppointmentStatus status, Expression<Func<appointmentsDTO, bool>> predicate = null, params Expression<Func<appointmentsDTO, object>>[] includeProperties)
        {
            var query = _context.appointments.Include(d => d.Doctor).Include(d => d.User)
               .AsNoTracking();

            if (status==0)
            {
               
                query = query.Where(a => a.Status == status);
            }
            var myAppointments = query
                .Select(a => new appointmentsDTO
                {
                    Id = a.Id,
                    AppointmentDate = a.AppointmentDate,
                    Day = a.AppointmentDate.DayOfWeek.ToString(),
                    Status = a.Status,
                    CreatedAt = a.CreatedAt,
                    PatientName = string.IsNullOrEmpty(a.PatientName) ? a.User.FullName : a.PatientName,
                    DoctorName = a.Doctor.Name,
                    TurnNumber = a.TurnNumber
                }).ToList();


            return myAppointments;


        }

        public async Task<List<appointmentsDTO>> GetAllAsync(AppointmentStatus status, Expression<Func<Appointments, bool>> predicate = null, params Expression<Func<Appointments, object>>[] includeProperties)
        {
            var query = _context.appointments.Include(d => d.Doctor).Include(d => d.User)
               .AsNoTracking();
            if (status != 0)
            {
                query = query.Where(a => a.Status == status);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var myAppointments = await query
                .Select(a => new appointmentsDTO
                {
                    Id = a.Id,
                    AppointmentDate = a.AppointmentDate,
                    Day = a.AppointmentDate.DayOfWeek.ToString(),
                    Status = a.Status,
                    CreatedAt = a.CreatedAt,
                    PatientName = string.IsNullOrEmpty(a.PatientName) ? a.User.FullName : a.PatientName,
                    DoctorName = a.Doctor.Name,
                    TurnNumber = a.TurnNumber
                })
                .ToListAsync();
            


            return myAppointments;
        }

 

        public bool ISNumberOfAppoinemtInDayFull(DateTime date, int doctorId, int appoinemntCount)
        {
            
            
            
            var maxAppointments = _context.doctorSchedules
               .Where(d => d.DoctorId == doctorId && d.DayOfWeek == (int)date.DayOfWeek)
               .Select(d => d.MaxAppointmentsPerDay)
               .FirstOrDefault();
            if (  appoinemntCount>= maxAppointments)
            {
                return true;
            }

            return false;
        }

        public async Task<OperationResult> UpdateAsync(UpdateAppoinemntDTO updateAppoinemntDTO, string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return OperationResult.Fail("المستخدم غير موجود.");

            var appoiment = await _context.appointments.FirstOrDefaultAsync(p => p.Id == updateAppoinemntDTO.id);
            if (appoiment is null)
                return OperationResult.Fail("الموعد غير موجود.");

            var doctor = await _context.Doctors.FirstOrDefaultAsync(u => u.Id == updateAppoinemntDTO.doctotId);
            if (doctor == null)
                return OperationResult.Fail("الطبيب غير موجود.");

            if (!IsDayExist(updateAppoinemntDTO.AppointmentDate))
                return OperationResult.Fail("الطبيب لا يعمل في هذا اليوم.");

       
            if (appoiment.AppointmentDate.Date != updateAppoinemntDTO.AppointmentDate.Date)
            {
                int appointmentCount = _context.appointments
                    .Count(a => a.DoctorId == updateAppoinemntDTO.doctotId && a.AppointmentDate.Date == updateAppoinemntDTO.AppointmentDate.Date);

                if (ISNumberOfAppoinemtInDayFull(updateAppoinemntDTO.AppointmentDate, updateAppoinemntDTO.doctotId, appointmentCount))
                    return OperationResult.Fail("تم الوصول للحد الأقصى من المواعيد في هذا اليوم.");
            }

      
            appoiment.AppointmentDate = updateAppoinemntDTO.AppointmentDate;
            appoiment.DoctorId = updateAppoinemntDTO.doctotId;
            appoiment.PatientName = updateAppoinemntDTO.PatientName ?? user.FullName;
            appoiment.Status = AppointmentStatus.Scheduled;
            appoiment.Notes = "";

            await _context.SaveChangesAsync();

            return OperationResult.Ok("تم تعديل الموعد بنجاح.");
        }

        private bool IsDayExist(DateTime date)
        {
            if (_context.doctorSchedules.Any(d => d.DayOfWeek == (int)date.DayOfWeek))
            {
                return true;
            }

            return false;
        }

       
    }
}
