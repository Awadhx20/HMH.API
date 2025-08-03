using HMH.Core.Entites;
using HMH.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Repositories.Service
{
    public class GenerateToken : IGenerateToken
    {
        private readonly IConfiguration configuration;

        public GenerateToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetAndGenerateToken(ApplicationUser user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),


            };
            var secrut = configuration["Token:Secret"];
            var Key = Encoding.ASCII.GetBytes(secrut);
            SigningCredentials signingCredentials =new SigningCredentials(new SymmetricSecurityKey(Key) , SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor tokenDescreptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                Issuer = configuration["Token:Issure"],
                SigningCredentials = signingCredentials
            };
            JwtSecurityTokenHandler hanlder = new JwtSecurityTokenHandler();
            var token = hanlder.CreateToken(tokenDescreptor);
            return hanlder.WriteToken(token);

        }
    }
}
