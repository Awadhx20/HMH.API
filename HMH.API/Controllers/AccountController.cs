using AutoMapper;
using HMH.API.Helper;
using HMH.core.Interfaces;
using HMH.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMH.API.Controllers
{

    public class AccountController : BaseController
    {
        public AccountController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                string result = await work.Auth.RegisterAsync(registerDTO);
                if(result!="done")
                {
                    return BadRequest(new ResponseAPI(400,result));
                }

                return Ok(new ResponseAPI(200, result));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var result = await work.Auth.LoginAsync(loginDTO);
                if (result.StartsWith("Please"))
                    return BadRequest(new ResponseAPI(400, result));

                Response.Cookies.Append("token", result, new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    Domain = "localhost",
                    Expires = DateTime.Now.AddDays(1),
                    IsEssential = true,
                    SameSite=SameSiteMode.Strict
                });
                return Ok(new ResponseAPI(200));

            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400));
            }
        }
    }
}
