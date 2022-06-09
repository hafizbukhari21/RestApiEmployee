using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.ViewModel;
using API.Repository.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using API.Utils;

namespace API.Services
{
    public class JWTConfig
    {

       

     
        public static string JwtParse(Object payload, IConfiguration _configuration)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Payload", JsonConvert.SerializeObject(payload, Formatting.Indented) ));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
       
            var jwtheader = new JwtHeader(signIn);
            var jwtpayload = new JwtPayload() {
                    {"Random-First",Tools.RandomString(10) },
                    {"payload",payload },
                    {"Random-End",Tools.RandomString(10)
                
                }
            };

            var token = new JwtSecurityToken(jwtheader, jwtpayload);
            var idtoken = new JwtSecurityTokenHandler().WriteToken(token);
            claims.Add(new Claim("TokenSecurity", idtoken.ToString()));

            return idtoken;
            
        }
    }
}
