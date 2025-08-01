using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Entites.Dectors
{
    public class DoctorSchedule:BaseEntity<int>
    {
       
        public int DayOfWeek { get; set; } // 0=Sunday, 6=Saturday
        
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MaxAppointmentsPerDay { get; set; }
        public int DoctorId { get; set; }

        //// Navigation property
      
        //public Doctor  Doctor { get; set; }
    }
}
