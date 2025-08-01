using HMH.core.Entites.Dectors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Entites
{
    public class Appointments:BaseEntity<int>
    {
        public DateTime AppointmentDate { get; set; } // تاريخ + وقت
        public string Status { get; set; } // معلّق، مؤكد، ملغى ...
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }     // تاريخ ووقت إنشاء الحجز
        public string PatientName { get; set; }
        // Navigation properties
        //public int UserId { get; set; }
        // public User User { get; set; }
        public int DoctorId { get; set; }

     
        //public Doctor  Doctor { get; set; }
    }
}
