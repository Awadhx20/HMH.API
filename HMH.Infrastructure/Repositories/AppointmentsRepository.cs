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
    public class AppointmentsRepository : GenericRepository<Appointments>, IAppointmentsRepository
    {
        public AppointmentsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
