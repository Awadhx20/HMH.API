using AutoMapper;
using HMH.core.Entites.Dectors;
using HMH.Core.DTO;

namespace HMH.API.Mapping
{
    public class DectorsMapping : Profile
    {
        public DectorsMapping()
        {
            CreateMap<Doctor, DoctorDTO>
                ().ForMember(x=>x.ClinicsName,op=>op.MapFrom(x=>x.Clinics.Name))
                .ReverseMap();

            CreateMap<AddDoctorDTO, Doctor>()
                .ForMember(x => x.ClinicsId, op => op.MapFrom(x => x.ClinicsID))
                .ReverseMap();
        }
    }
}
