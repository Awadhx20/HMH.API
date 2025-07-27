using HMH.core.Entites;
using HMH.core.Interfaces;
using HMH.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Repositories
{
    public class ClinicsRepository : GenericRepository<Clinics>, IClinicsRepository
    {
        public ClinicsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
