using HMH.core.Entites.Dectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Interfaces
{
    public interface IDoctorScheduleRepository:IGenericRepository<DoctorSchedule>
    {
        Task<bool> ExistsAsync(int doctorid, DayOfWeek DayInWeek);
        List<DateTime> GenerateUpcomingDates(List<int> workingDays, int daysAhead);
        List<(DateTime Date, TimeSpan StartTime, TimeSpan EndTime, int DayOfWeek)>
            GenerateUpcomingDatesWithTimes(List<DoctorSchedule> doctorSchedules, int daysAhead = 30);
    }
}
