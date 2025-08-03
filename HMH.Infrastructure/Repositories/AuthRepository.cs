using HMH.Core.DTO;
using HMH.Core.Entites;
using HMH.Core.Interfaces;
using HMH.Core.Services;
using HMH.Core.Sharing;
using HMH.Infrastructure.Repositories.Service;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace HMH.Infrastructure.Repositories
{
    public class AuthRepository:IAuth
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IGenerateToken generateToken;
        public AuthRepository(UserManager<ApplicationUser> userManager, IEmailService emailService, SignInManager<ApplicationUser> signInManager, IGenerateToken token)
        {
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
            this.generateToken = token;
        }


        public async Task<string> RegisterAsync(RegisterDTO registerDTO)
        {
            if (registerDTO == null) return null;

            if(await _userManager.FindByNameAsync(registerDTO.UserName) is not null)
            {
                return "This username is already register ";
            }


            if (await _userManager.FindByEmailAsync(registerDTO.Email) is not null)
            {
                return "This email is already register ";
            }

            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerDTO.UserName,
                Email=registerDTO.Email,
                FullName=registerDTO.FullName,

            };
            var result =await _userManager.CreateAsync(user,registerDTO.Password);
            if (result.Succeeded is not true)
            {
                return result.Errors.ToList()[0].Description;
            }
            string code =await _userManager.GenerateEmailConfirmationTokenAsync(user);
            SendEmail(user.Email, code, "active", "Active Email", "يرجى تاكيد الايميل الخاص فيك ");

            //email sender ;
            return "done";



        }

        public async Task SendEmail(string Email , string code , string component , string subject , string Message)
        {
            var result = new EmailDTO(Email, "hadramout.modren.hospital@gmail.com",
                subject, EmailStringBody.Send(Email , code , component ,Message));
            await _emailService.SendEmailAsync(result);
        }



        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO == null) return null;
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user is null) return " not found user  ";
            if(!user.EmailConfirmed)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                SendEmail(user.Email, token, "active", "Active Email", "يرجى تاكيد الايميل الخاص فيك ");
                return "Please confirem email first , we have send activat to Your  email ";
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user , loginDTO.Password , true);// five request if not login bloced 
            if(result.Succeeded)
            {
                return generateToken.GetAndGenerateToken(user);
            }

            return "Please check you email or password , something went worn";

        }
    }
}
