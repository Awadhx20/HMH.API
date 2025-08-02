using AutoMapper;
using HMH.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HMH.API.Controllers
{
 
    public class BugController : BaseController
    {
        public BugController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpGet("not-found")]
        public async Task<ActionResult> GetNotFound()
        {
            var clinics = await work.clinicsRepository.GetByIdAsync(100);
            if (clinics is null)  return NotFound();
            return Ok(clinics);
        }
        [HttpGet("server-error")]
        public async Task<ActionResult> GetServerError()
        {
            var clinics = await work.clinicsRepository.GetByIdAsync(100);
            clinics.Name = "";
            return Ok(clinics);
        }

        [HttpGet("Bad-request/{id}")]
        public async Task<ActionResult> GetBadRequest(int id )
        {
            
            return Ok();
        }

        [HttpGet("Bad-request/")]
        public async Task<ActionResult> GetBadRequest()
        {

            return Ok();
        }


    }
}
