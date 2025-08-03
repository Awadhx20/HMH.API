using HMH.core.Entites.Dectors;
using HMH.core.Interfaces;
using HMH.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Repositories
{
    public class DoctorScheduleRepository : GenericRepository<DoctorSchedule>, IDoctorScheduleRepository
    {
        private readonly AppDbContext _context;

        public DoctorScheduleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<bool> ExistsAsync(int doctorid, DayOfWeek DayInWeek)
        {
            return _context.doctorSchedules.AnyAsync(d => d.DoctorId == doctorid && d.DayOfWeek == (int)DayInWeek);
        }
    }
}
