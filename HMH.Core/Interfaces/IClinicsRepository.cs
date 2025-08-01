
using HMH.core.Entites;
using HMH.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.core.Interfaces
{
    public interface IClinicsRepository:IGenericRepository<Clinics>
    {
        Task<bool> AddAsync(AddClinicsDto clinicsDto);
        Task<bool> UpdateAsync(UpdateClinicsDto clinicsDto);
        Task DeleteAsync(Clinics clinicsDto);

    }
}
