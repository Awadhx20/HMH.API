using HMH.core.Entites;
using HMH.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.DTO
{
    public record appointmentsDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Day { get; set; }// تاريخ + وقت
        public int TurnNumber { get; set; }
        public AppointmentStatus Status { get; set; } // معلّق، مؤكد، ملغى ...
        //public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }     // تاريخ ووقت إنشاء الحجز
        public string PatientName { get; set; }
        // Navigation properties
        public string DoctorName { get; set; }
    }


    public record AddappointmentsDTO
    {
      
        public DateTime AppointmentDate { get; set; }
        // تاريخ ووقت إنشاء الحجز
        public string PatientName { get; set; }
         public int doctotId { get; set; }
        // Navigation properties
      
    }


    public record UpdateAppoinemntDTO:AddappointmentsDTO
    {
        public int id { get; set; }

    }
}
