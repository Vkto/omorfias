using API.Omorfias.DataAgent.Interfaces;
using API.Omorfias.Domain.Interfaces.Configuracoes;
using API.Omorfias.Domain.Models;
using System;

namespace API.Omorfias.DataAgent
{
   public  class DataAgent : IDataAgent
    {
        private readonly string _accessToken;
        public DataAgent(IGerenciadorDeConfiguracoes gerenciadorDeConfiguracoes)
        {
            _accessToken = gerenciadorDeConfiguracoes.ObterValor<string>("SecurityToken");
        
        }

        //public static string GenerateToken(User user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(Settings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Username.ToString()),
        //            new Claim(ClaimTypes.Role, user.Role.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddHours(2),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

    }
}
