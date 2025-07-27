using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Entites
{
    public class Offer:BaseEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Discount { get; set; }
        public string BookingUrl { get; set; }    
        public DateTime CreatedAt { get; set; }
    }
}
