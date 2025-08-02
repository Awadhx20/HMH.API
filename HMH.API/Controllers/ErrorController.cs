using HMH.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMH.API.Controllers
{
    [Route("errors/{statuesCode}")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error (int statuesCode)
        {
            return new ObjectResult(new ResponseAPI(statuesCode));
        }
    }
}
