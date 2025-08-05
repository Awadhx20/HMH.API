using HMH.core.Entites;
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


//public class Offer : BaseEntity<int>
//{
//    public string Title { get; set; }
//    public string Content { get; set; }
//    public int Discount { get; set; }
//    public DateTime CreatedAt { get; set; }

//    // بدل URL نستخدم حقل لتوجيه التطبيق داخلياً
//    public string TargetPage { get; set; }  // مثال: "BookingPage", "HomePage", "OfferDetails"
//    public int? DoctorId { get; set; }      // خيار توجيه مرتبط بمعرف طبيب مثلاً
//}

