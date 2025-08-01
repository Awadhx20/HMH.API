using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Core.DTO
{
    public record DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public int Experience { get; set; }
        //public int Rating { get; set; }
        public string Specialty { get; set; }

        public string ClinicsName { get; set; }

    }


    public record AddDoctorDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public int Experience { get; set; }
        //public int Rating { get; set; }
        public string Specialty { get; set; }

        public int ClinicsID { get; set; }

    }

    public record UpdateDoctorDTO : AddDoctorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public IFormFile? Image { get; set; }

        public int Experience { get; set; }
        //public int Rating { get; set; }
        public string Specialty { get; set; }

        public int ClinicsID { get; set; }
    }



}
