using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.DTO
{
    public record DoctorScheduleDTO
    {
        public int Id { get; set; }

       
        public DayOfWeek DayOfWeek { get; set; } // 0=Sunday, 6=Saturday

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int MaxAppointmentsPerDay { get; set; }
       
    }

    public record AddDoctorScheduleDTO:IValidatableObject
    {
        [Range(0, 6, ErrorMessage = "اليوم يجب أن يكون رقماً من 0 إلى 6 (الأحد إلى السبت).")]
      
        public DayOfWeek DayOfWeek { get; set; }
       
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Range(1, 80, ErrorMessage = "عدد المواعيد يجب أن يكون رقماً صحيحاً أكبر من 0.")]
        public int MaxAppointmentsPerDay { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartTime >= EndTime)
            {
                yield return new ValidationResult(
                    "وقت البدء يجب أن يكون قبل وقت الانتهاء.",
                    new[] { nameof(StartTime), nameof(EndTime) }
                );
            }
        }
    }

    public record updateDoctorScheduleDTO:IValidatableObject
    {
        //[Range(0, 6, ErrorMessage = "اليوم يجب أن يكون رقماً من 0 إلى 6 (الأحد إلى السبت).")]

        //public DayOfWeek DayOfWeek { get; set; }
       
        
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Range(1, 80, ErrorMessage = "عدد المواعيد يجب أن يكون رقماً صحيحاً أكبر من 0.")]
        public int MaxAppointmentsPerDay { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartTime >= EndTime)
            {
                yield return new ValidationResult(
                    "وقت البدء يجب أن يكون قبل وقت الانتهاء.",
                    new[] { nameof(StartTime), nameof(EndTime) }
                );
            }
        }
    }
}
