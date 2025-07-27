using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Entites.Dectors
{
    public class Doctor : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public int Experience { get; set; }
        public string Specialty { get; set; }

        public int ClinicsId { get; set; }
       
        public virtual Clinics Clinics { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }= new HashSet<Ratings>();

       
        public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new HashSet<DoctorSchedule>();


        public virtual ICollection<Appointments>Appointments { get; set; } = new HashSet<Appointments>();








        //public int MyProperty { get; set; }التخصص 


    }
}
