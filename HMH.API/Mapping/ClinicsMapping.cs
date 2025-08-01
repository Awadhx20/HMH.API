using AutoMapper;
using HMH.core.Entites;
using HMH.Core.DTO;

namespace HMH.API.Mapping
{

    public class ClinicsMapping:Profile 
    {
        public ClinicsMapping()
        {
            CreateMap<ClinicsDto, Clinics>().ReverseMap();
            CreateMap<UpdateClinicsDto, Clinics>().ReverseMap();
            CreateMap<Clinics, AddClinicsDto>().ReverseMap();
        }
    }
}
