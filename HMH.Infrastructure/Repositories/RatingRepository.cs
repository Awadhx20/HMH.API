using HMH.core.Entites.Dectors;
using HMH.core.Interfaces;
using HMH.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Repositories
{
    public class RatingRepository : GenericRepository<Ratings>, IRatingRepository
    {
        private readonly AppDbContext context;

        public RatingRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<float> CountOfDoctorRating(int DoctorId)
        {
            var count= context.ratings.Where(r=>r.DoctorId== DoctorId);
           
            float ratcount = 0;
            foreach(var rat in count)
            {
                ratcount += rat.Stars;
            }
            return  ratcount / count.Count();
        }
    }
}
