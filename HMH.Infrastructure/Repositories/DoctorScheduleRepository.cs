using HMH.core.Entites;
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

        public List<DateTime> GenerateUpcomingDates(List<int> workingDays, int daysAhead)
        {
            var today = DateTime.Today;
            var endDate = today.AddDays(daysAhead);
            var dates = new List<DateTime>();

            for (var date = today; date <= endDate; date = date.AddDays(1))
            {
                if (workingDays.Contains((int)date.DayOfWeek))
                {
                    dates.Add(date);
                }
            }

            return dates;
        }

        public List<(DateTime Date, TimeSpan StartTime, TimeSpan EndTime, int DayOfWeek)> GenerateUpcomingDatesWithTimes(
             List<DoctorSchedule> doctorSchedules,
                int daysAhead = 30)
        {
            var today = DateTime.Today;
            var endDate = today.AddDays(daysAhead);
            var result = new List<(DateTime, TimeSpan, TimeSpan, int)>();

            for (var date = today; date <= endDate; date = date.AddDays(1))
            {
                var dow = (int)date.DayOfWeek;
                var match = doctorSchedules.FirstOrDefault(s => s.DayOfWeek == dow);
                if (match != null)
                {
                    result.Add((date, match.StartTime, match.EndTime, match.DayOfWeek));
                }
            }

            return result;
        }
    }
}
