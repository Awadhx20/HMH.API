using HMH.Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string UserId { get; set; }

        // Navigation property 
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
