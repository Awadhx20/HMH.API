using HMH.core.Entites.Dectors;
using HMH.Core.Entites;
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
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        public int DoctorId { get; set; }

     
        //public Doctor  Doctor { get; set; }
    }
}
