using AutoMapper;
using HMH.API.Helper;
using HMH.core.Entites.Dectors;
using HMH.core.Interfaces;
using HMH.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMH.API.Controllers
{

    public class DoctorController : BaseController
    {



        public DoctorController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }


        [HttpGet("get-aLl")]
        public async Task<IActionResult> get()
        {
            try
            {
                var doctor = await work.doctorRepository.GetAllAsync(d => d.Clinics);

                var result = mapper.Map<List<DoctorDTO>>(doctor);
                if (doctor == null) return BadRequest(new ResponseAPI(400));
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-Id/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var doctor = await work.doctorRepository.GetByIdAsync(id, x => x.Clinics);
                var result = mapper.Map<DoctorDTO>(doctor);
                if (doctor is null) return BadRequest(new ResponseAPI(400, $"not found doctor id ={id}"));
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400));
            }
        }

        [HttpPost("Add-Doctor")]
        public async Task<IActionResult> Add(AddDoctorDTO doctor)
        {
            try
            {


                if (!await work.doctorRepository.AddAsync(doctor)) return BadRequest(new ResponseAPI(400));
                return Ok(new ResponseAPI(200, "item has been Added"));

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        [HttpPut("Update-Doctor")]
        public async Task<IActionResult> Update(UpdateDoctorDTO doctorDto)
        {
            try
            {
                
                var docotr = await work.doctorRepository.UpdateAsync(doctorDto);
                if (!docotr) return BadRequest(new ResponseAPI(400));
                return Ok(new ResponseAPI(200, "Item as been updated"));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400));
            }


        }
        // deleted method in  docotor controller and  push in Github repo 
        [HttpDelete("Delete-Doctor/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var doctor =await  work.doctorRepository.GetByIdAsync(id);
                if (doctor is null) return BadRequest(new ResponseAPI(400));
                await work.doctorRepository.DeleteAsync(doctor);
                return Ok(new ResponseAPI(200, "item has been deleted "));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
