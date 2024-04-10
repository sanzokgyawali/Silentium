
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousChat
{
    public class JWT
    {
        private readonly IConfiguration _configuration;
        //private readonly IConfiguration _configuration;
        public JWT(IConfiguration configuration) 
        {
           _configuration = configuration;
        
        }


        public string GenerateJWT(string userID)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userID)
            };

            var keyAsString = _configuration["Authentication:JwtBearer:SecurityKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyAsString));
            var token = new JwtSecurityToken(
               issuer: _configuration["Authentication:Issuer"],
               audience: _configuration["Authentication:Audience"],
               claims: claims,
               expires: DateTime.Now.AddDays(30),
               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenAsString;
        }
    }
}
