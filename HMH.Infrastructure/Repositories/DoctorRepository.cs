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
    internal class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
