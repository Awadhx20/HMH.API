using AutoMapper;
using HMH.API.Helper;
using HMH.core.Entites;
using HMH.core.Interfaces;
using HMH.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace HMH.API.Controllers
{
   
    public class AppointmentController : BaseController
    {
        public AppointmentController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }


        [HttpGet("my-appointments")]
        [Authorize]
        public async Task<IActionResult> GetMyAppointments(AppointmentStatus status)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (email == null)
                return Unauthorized();

            
            var myAppointments = await work.appointmentsRepository.GetAllAsync(status, predicate: a => a.User.Email == email);
            return Ok(myAppointments);
        }


        [HttpPost("add-appointments/{DoctorId}")]
        public async Task<IActionResult> Add(int DoctorId, AddappointmentsDTO addappointmentsDTO)
        {
            //add doctor id into addappoinementDto 
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                if (email == null)
                    return Unauthorized();

                var result = await work.appointmentsRepository.AddAsync(DoctorId, addappointmentsDTO, email);

                if (!result.Success)
                    return BadRequest(new ResponseAPI(400, result.Message));

                return Ok(new ResponseAPI(200, result.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(500, ex.Message));
            }
        }


        [HttpPut("Update-appointments")]
        public async Task<IActionResult> Update( UpdateAppoinemntDTO updateAppoinemnt)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                if (email == null)
                    return Unauthorized();

                var result = await work.appointmentsRepository.UpdateAsync( updateAppoinemnt, email);

                if (!result.Success)
                    return BadRequest(new ResponseAPI(400, result.Message));

                return Ok(new ResponseAPI(200, result.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(500, ex.Message));
            }
        }
        [HttpPut("cancel-appointment/{appointmentId}")]
        [Authorize]
        public async Task<IActionResult> CancelAppointment(int appointmentId)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                if (email == null)
                    return Unauthorized();

                var result = await work.appointmentsRepository.CancelAsync(appointmentId, email);

                if (!result.Success)
                    return BadRequest(new ResponseAPI(400, result.Message));

                return Ok(new ResponseAPI(200, result.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(500, ex.Message));
            }
        }







    }
}
