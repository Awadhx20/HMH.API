using HMH.core.Entites.Dectors;
using HMH.core.Interfaces;
using HMH.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Repositories
{
    public class RatingRepository : GenericRepository<Ratings>, IRatingRepository
    {
        public RatingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
