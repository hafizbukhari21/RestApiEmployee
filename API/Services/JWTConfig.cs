using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.ViewModel;
using API.Repository.Data;
namespace API.Services
{
    public class JWTConfig
    {
        //public static JwtSecurityTokenHandler GetTokenLogin(LoginPegawaiVM loginvm)
        //{
        //    AccountRepository acr = new AccountRepository();
        //    var claims = new List<Claim>();
        //    claims.Add(new Claim("Email", loginvm.email);
        //    foreach (var claim in  acr.GetAccountRoles(loginvm.email))
        //    {
        //        claims.Add(new Claim("rolse", ));
        //    }
        //}
    }
}
