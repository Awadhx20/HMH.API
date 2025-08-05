using AutoMapper;
using HMH.core.Entites;
using HMH.core.Entites.Dectors;
using HMH.core.Interfaces;
using HMH.Core.DTO;
using HMH.Core.Services;
using HMH.Core.Sharing;
using HMH.Infrastructure.Data;
using HMH.Infrastructure.Repositories.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Repositories
{
    internal class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {

        private readonly IMapper mapper;
        private readonly AppDbContext _context;
        private readonly IimageserviceMangment iimageserviceMangment;
        public DoctorRepository(AppDbContext context, IMapper mapper, IimageserviceMangment iimageserviceMangment) : base(context)
        {
            _context = context;
            this.mapper = mapper;
            this.iimageserviceMangment = iimageserviceMangment;
        }

        public async Task<bool> AddAsync(AddDoctorDTO doctorDTO)
        {
            if (doctorDTO == null) return false;

            Doctor doctor =  mapper.Map<Doctor>(doctorDTO);
            if (!isClinicExest(doctor.ClinicsId)) return false;
            var imagepath = await iimageserviceMangment.AddImageAsync(doctorDTO.Image, doctorDTO.Name);
            doctor.Image = imagepath;
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return true ;
        }

        public async Task<bool> UpdateAsync(UpdateDoctorDTO doctorDTO)
        {
            if (doctorDTO is null) return false;

            var docotr = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctorDTO.Id);
            if (docotr is null || !isClinicExest(docotr.ClinicsId)) return false;
            
            docotr.Name = doctorDTO.Name;
            docotr.Specialty = doctorDTO.Specialty;
            docotr.ClinicsId = doctorDTO.ClinicsID;
            docotr.Experience = doctorDTO.Experience;
            docotr.Description = doctorDTO.Description;
            
            //docotr.Image = iimageserviceMangment.AddImageAsync doctorDTO.Specialty;
           
            

            
            if (doctorDTO.Image is not null )
            {
                iimageserviceMangment.DeleteImageAsync(docotr.Name);
                docotr.Image = await iimageserviceMangment.AddImageAsync(doctorDTO.Image, doctorDTO.Name);

            }
            
            _context.Doctors.Update(docotr);
            await _context.SaveChangesAsync();
            //clinicsDto.image = await imageserviceMangment.AddImageAsync(clinicsDto.image, clinicsDto.name);
            return true;
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            if (doctor is null) return;
            iimageserviceMangment.DeleteImageAsync(doctor.Name);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
        private bool isClinicExest(int id)
        {
            return _context.clinics.Any(c => c.Id == id);
        }

        private decimal RatingOfDoctor(int doctorId)
        {
            var ratings = _context.ratings.Where(r => r.DoctorId == doctorId);

            if (!ratings.Any())
                return 0m;

            var avg = ratings.Average(r => r.Stars);
            return Math.Round((decimal)avg, 2);
        }


        public async Task<IEnumerable<DoctorDTO>> GetAllAsync(DoctorParam param)
        {
            var query = _context.Doctors.Include(d => d.Clinics)
                 .AsNoTracking();

            if (param.clinicsId.HasValue)
            {
                query = query.Where(d => d.ClinicsId == param.clinicsId);
            }
            if(!string.IsNullOrEmpty(param.search))
            {
                var Searchword = param.search.Split(' ');
                query = query.Where(m => Searchword.All(word =>
                m.Name.ToLower().Contains(word.ToLower()) ||
                m.Description.ToLower().Contains(word.ToLower())
                ));
            }

            query = query.Skip(param.pageSize *(param.PageNumber - 1)).Take(param.pageSize);
            

            var result =  mapper.Map<List<DoctorDTO>>(query);
            foreach (var doctor in result)
            {
                var rating = RatingOfDoctor(doctor.Id);
                doctor.Rating = rating.ToString("F2");
            }

            //var result = mapper.Map<List<DoctorDTO>>(query);
            return result;
        }

       
    }
}
