using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.DTO
{
    public record ClinicsDto(string name , string image);

    public class ClinicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<DoctorDTO> Doctors { get; set; }
    }


    public record AddClinicsDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }

    public record UpdateClinicsDto 
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? Image { get; set; } = null;
    }


}
