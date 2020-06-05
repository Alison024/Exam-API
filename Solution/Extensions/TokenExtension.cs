using Solution.Domain.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
namespace Solution.Extensions
{
    public static class TokenExtension
    {
        public static void GenerateToken(this Customer customer, string secret, int expire){
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name, customer.Name)  
            };
            var roleClaims = customer.UserRoles.Select(x => new Claim(ClaimTypes.Role, x.Role.Name));
            claims.AddRange(roleClaims);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(expire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            customer.Token = tokenHandler.WriteToken(token);
            customer.Password = null;
        }
    }
}