using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Entites.Dectors
{
    public class Ratings:BaseEntity<int>
    {
       
       
        public int Stars { get; set; } // 1 إلى 5
        public string Comment { get; set; }
        public DateTime RatedAt { get; set; }
        //public int UserId { get; set; }
        public int DoctorId { get; set; }
        // Navigation properties
        //public User User { get; set; }
        //[ForeignKey(nameof(DoctorId))]
        //public Doctor Doctor { get; set; }=
        
    }
}
