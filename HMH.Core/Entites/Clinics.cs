using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HMH.core.Entites.Dectors;

namespace HMH.core.Entites
{
    public class Clinics:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
