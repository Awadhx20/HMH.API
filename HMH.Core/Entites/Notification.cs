using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Entites
{
    public class Notification:BaseEntity<int>
    {
        public string Title { get; set; }             
        public string Message { get; set; }           
        public bool IsRead { get; set; }              
        public DateTime CreatedAt { get; set; }       
        //public int UserId { get; set; }               

        // Navigation property 
        //public User User { get; set; }
    }
}
