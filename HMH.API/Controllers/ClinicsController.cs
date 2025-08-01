using AutoMapper;
using HMH.API.Helper;
using HMH.core.Entites;
using HMH.core.Interfaces;
using HMH.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HMH.API.Controllers
{

    public class ClinicsController : BaseController
    {
        public ClinicsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("get-All")]
        public async Task<IActionResult> get()
        {
            try
            {
                
                var clinics = await work.clinicsRepository.GetAllAsync();
                if (clinics is null)

                    return BadRequest(new ResponseAPI(400));
                return Ok(clinics);
                //for get clinics with Doctors 
                //var clinics = await work.clinicsRepository.GetAllAsync(x => x.Doctors);
                //if (clinics == null)
                //    return BadRequest(new ResponseAPI(400));

                //var result = clinics.Select(c => new ClinicDto
                //{
                //    Id = c.Id,
                //    Name = c.Name,
                //    Image = c.Image,
                //    Doctors = c.Doctors.Select(d => new DoctorDTO
                //    {
                //        Id = d.Id,
                //        Name = d.Name,
                //        Specialty = d.Specialty,
                //        Experience = d.Experience,
                //        Image = d.Image,
                //        Description = d.Description
                //    }).ToList()
                //}).ToList();

                //return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400,ex.Message));

            }
        }


        [HttpGet("get-By-ID/{id}")]
        public async Task<IActionResult> getbyId(int id)
        {
            try
            {
                var clinces = await work.clinicsRepository.GetByIdAsync(id);
                if (clinces is null) return BadRequest(new ResponseAPI(400, $" not found CLini id = {id} "));
                return Ok(clinces);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }


        [HttpPost("Add-Clinics")]
        public async Task<IActionResult> Add(AddClinicsDto clinicsDto)
        {
            try
            {



               
                await work.clinicsRepository.AddAsync(clinicsDto);

                return Ok(new ResponseAPI( 200,"Clinics is added sussufll"));
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }


        [HttpPut("Update-Clinics")]
        public async Task<IActionResult> update(UpdateClinicsDto clinicsDto)
        {
            try
            {
              

                var clinic = await work.clinicsRepository.UpdateAsync(clinicsDto);
                if (!clinic) return BadRequest(new ResponseAPI(400));
                return Ok(new ResponseAPI(200, "CLinics is update " ));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }


        [HttpDelete("Delete-Clinics/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var clinic = await work.clinicsRepository.GetByIdAsync(id);
                await work.clinicsRepository.DeleteAsync(clinic);
                return Ok(new ResponseAPI(200 ,"Clinics is deleted Sussfully" ));
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
