using AutoMapper;
using AutoMapper.QueryableExtensions;
using HMH.core.Entites;
using HMH.core.Interfaces;
using HMH.Core.DTO;
using HMH.Core.Services;
using HMH.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Repositories
{
    public class ClinicsRepository : GenericRepository<Clinics>, IClinicsRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IimageserviceMangment imageserviceMangment;

        public ClinicsRepository(AppDbContext context, IMapper mapper, IimageserviceMangment imageserviceMangment) : base(context)
        {
            this._mapper = mapper;
            _context = context;
            this.imageserviceMangment = imageserviceMangment;
        }

        public async Task<bool> AddAsync(AddClinicsDto clinicsDto)
        {
            if (clinicsDto is null) return false;

            var clinics =_mapper.Map<Clinics>(clinicsDto);
            
            var imagepath = await imageserviceMangment.AddImageAsync(clinicsDto.Image, clinicsDto.Name);
            clinics.Image =  imagepath;
           
            await _context.clinics.AddAsync(clinics);
            await _context.SaveChangesAsync();
            return true;  
            

            
        }


        public async Task<bool> UpdateAsync(UpdateClinicsDto clinicsDto)
        {
            if (clinicsDto is null) return false;

            var findClinic =await _context.clinics.FirstOrDefaultAsync(x => x.Id == clinicsDto.Id);
            if (findClinic is null) return false;
            
             findClinic.Name=clinicsDto.Name;
            if (clinicsDto.Image is not null)
            {
                imageserviceMangment.DeleteImageAsync(clinicsDto.Name);

                findClinic.Image = await imageserviceMangment.AddImageAsync(clinicsDto.Image, clinicsDto.Name);
            }
             
             _context.clinics.Update(findClinic);
            await _context.SaveChangesAsync();
            //clinicsDto.image = await imageserviceMangment.AddImageAsync(clinicsDto.image, clinicsDto.name);
            return true;
        }
        public async  Task DeleteAsync(Clinics clinicsDto)
        {
            if (clinicsDto is null) return ;
            imageserviceMangment.DeleteImageAsync(clinicsDto.Name);
            _context.clinics.Remove(clinicsDto);
            await _context.SaveChangesAsync();

        }
        
    }
}
