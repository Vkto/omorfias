
using API.Omorfias.Data.Models;
using API.Omorfias.DataAgent.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Omorfias.DataAgent.Services
{
    public class DataAgentService : IDataAgentService
    {
        private readonly string _accessToken = "SECRETSECRETSECRETSECRETSECRETSECRETSECRET";

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_accessToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", user.Name),
                    new Claim("lastName", user.LastName),
                    new Claim("email", user.Email),

                }),
                Expires = DateTime.UtcNow.AddHours(72),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
