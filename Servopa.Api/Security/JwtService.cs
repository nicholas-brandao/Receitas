using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Servopa.Api.Model;
using Servopa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Servopa.Api.Security
{
    public class JwtService
    {
        private readonly IConfiguration Configuration;

        public JwtService(IConfiguration config)
        {
            Configuration = config;
        }

        public string AutenticarUsuarioJwt(UserLogin user)
        {
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.User),
                    new Claim("Servopa", "user")
                }),
                Issuer = Configuration["Jwt:Issuer"],
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
