using HMH.core.Entites.Dectors;
using HMH.Core.DTO;
using HMH.Core.Sharing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Interfaces
{
    public interface IDoctorRepository:IGenericRepository<Doctor>
    {
        //
        Task<bool> AddAsync(AddDoctorDTO doctorDTO);
        Task<IEnumerable<DoctorDTO>> GetAllAsync(DoctorParam param);
        Task<bool> UpdateAsync(UpdateDoctorDTO doctorDTO);
        Task DeleteAsync(Doctor doctor);

       
    }
}
