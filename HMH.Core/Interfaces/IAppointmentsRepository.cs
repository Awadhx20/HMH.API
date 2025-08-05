using HMH.core.Entites;
using HMH.Core.DTO;

using HMH.Core.Entites;
using HMH.Core.Sharing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Interfaces
{
    public interface IAppointmentsRepository:IGenericRepository<Appointments>
    {
        Task<List<appointmentsDTO>> GetAllAsync( AppointmentStatus status,
             Expression<Func<Appointments, bool>> predicate = null,
             params Expression<Func<Appointments, object>>[] includeProperties);

        Task<OperationResult> AddAsync(int DoctorID,AddappointmentsDTO entity, string Email);
        Task<OperationResult> UpdateAsync(UpdateAppoinemntDTO updateAppoinemntDTO, string Email);
        Task<OperationResult> CancelAsync(int appoinmentId, string Email);

       bool ISNumberOfAppoinemtInDayFull(DateTime date, int doctorId, int appoinemntCount);
    }
}
