using AutoMapper;
using HMH.API.Helper;
using HMH.API.Mapping;
using HMH.core.Entites.Dectors;
using HMH.core.Interfaces;
using HMH.Core.DTO;
using HMH.Core.Sharing;
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
        public async Task<IActionResult> get([FromQuery]DoctorParam param)
        {
            try
            {
                var doctor = await work.doctorRepository.GetAllAsync(param);
                int count = doctor.Count();
                //var count = await work.doctorRepository.CountAsync();
                
                if (doctor == null) return BadRequest(new ResponseAPI(400));
                return Ok(new Pagination<DoctorDTO>(param.pageSize, param.PageNumber, count, doctor));
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


        [HttpGet("Doctor/{doctorId}/schedules")]
        public async Task<IActionResult> GetSchedules(int doctorId)
        {
            try
            {
                var doctor = await work.doctorRepository.GetByIdAsync(doctorId, d => d.DoctorSchedules);
              
                if (doctor == null)
                    return NotFound(new ResponseAPI(404, "Doctor not found"));

                var schedules = mapper.Map<List<DoctorScheduleDTO>>(doctor.DoctorSchedules);
                
                //var schedules = mapper.Map<List<DoctorScheduleDTO>>(doctor.DoctorSchedules);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("{doctorId}/schedules")]
        public async Task<IActionResult> AddSchedule(int doctorId,  AddDoctorScheduleDTO addDoctorSchedule)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var exists = await work.doctorScheduleRepository
                      .ExistsAsync(doctorId, addDoctorSchedule.DayOfWeek);

                if (exists)
                    return BadRequest(new ResponseAPI(400, "Schedule for this day already exists for the doctor."));
                

                var doctor = await work.doctorRepository.GetByIdAsync(doctorId);
                if (doctor == null) return NotFound(new ResponseAPI(404, "Doctor not found"));

                var schedule = mapper.Map<DoctorSchedule>(addDoctorSchedule);
                schedule.DoctorId = doctorId;

                await work.doctorScheduleRepository.AddAsync(schedule);


                return Ok(new ResponseAPI(200, $"Schedule added "));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400));
            }
           

            
        }

        [HttpPut("{doctorId}/schedules/{scheduleId}")]
        public async Task<IActionResult> UpdateSchedule(int doctorId, int scheduleId, updateDoctorScheduleDTO updateDoctorSchedule)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var schedule = await work.doctorScheduleRepository.GetByIdAsync(scheduleId);
                if (schedule == null || schedule.DoctorId != doctorId)
                    return NotFound(new ResponseAPI(404, "Schedule not found"));

                // لا تعمل Map لكائن جديد، بل حدّث القيم مباشرة
                schedule.StartTime = updateDoctorSchedule.StartTime;
                schedule.EndTime = updateDoctorSchedule.EndTime;
                schedule.MaxAppointmentsPerDay = updateDoctorSchedule.MaxAppointmentsPerDay;

                await work.doctorScheduleRepository.UpdateAsync(schedule);

                return Ok(new ResponseAPI(200, "Schedule updated"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }


        [HttpDelete("{doctorId}/schedules/{scheduleId}")]
        public async Task<IActionResult> DeleteSchedule(int doctorId, int scheduleId)
        {
            try
            {
                var schedule = await work.doctorScheduleRepository.GetByIdAsync(scheduleId);
                if (schedule == null || schedule.DoctorId != doctorId)
                    return NotFound(new ResponseAPI(404, "Schedule not found"));

                await work.doctorScheduleRepository.DeleteAsync(schedule.Id);


                return Ok(new ResponseAPI(200, "Schedule deleted"));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400));
            }
            
        }



    }
}
