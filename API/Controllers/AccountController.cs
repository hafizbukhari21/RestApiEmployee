using API.Models;
using API.Repository.Data;
using API.Services;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/account/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account,AccountRepository, string>
    {
        public IConfiguration _configuration;
        public AccountRepository accountRepository;
        public AccountController (AccountRepository accountRepository, IConfiguration configuration) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this._configuration = configuration;
        }

        [HttpPost("forgotPassword")]
        public ActionResult ForgotPassword(ForgotPasswordVM forgotPassswordVM)
        {
            return Ok(accountRepository.ActivateForgotPassword(forgotPassswordVM));
        }

        [HttpPost("validateForgotPassword")]

        public ActionResult ValidateForgotPassword(ForgotPasswordValidateVM forgotPasswordValidateVM)
        {
            return Ok(accountRepository.ValidateForgotPassword(forgotPasswordValidateVM));
        }



        [HttpPost("cobalogin")]
        public ActionResult GetLogin(LoginPegawaiVM loginPegawaiVM)
        {
            if (accountRepository.Login(loginPegawaiVM) == Variable.EMAIL_NOT_FOUND) 
                return StatusCode(202, new { Message="email tidak sesuai" });
            else if (accountRepository.Login(loginPegawaiVM) == Variable.PASSWORD_NOT_FOUND) 
                return StatusCode(202, new { Message = "password tidak sesuai" });
            else 
                return StatusCode(202, new { Message = "Berhasil login" });
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginPegawaiVM loginPegawaiVM)
        {
            if (accountRepository.Login(loginPegawaiVM) == 200)
            {
               
                var claims = new List<Claim>();
                claims.Add(new Claim("Email", loginPegawaiVM.email));
                foreach (var role in accountRepository.GetAccountRoles(loginPegawaiVM.email))
                {
                    claims.Add(new Claim("roles",role.nama_role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(18),
                    signingCredentials: signIn
                    );
                var idtoken = new JwtSecurityTokenHandler().WriteToken(token);
                claims.Add(new Claim("TokenSecurity", idtoken.ToString()));
                return Ok(new { StatusCode = HttpStatusCode.OK ,idtoken, message="berhasil" });
            }
            return BadRequest();
        }

        [Authorize(Roles = "Direktur")]
        [HttpPost("SetManager")]
        public ActionResult SetManager(InsertManagerVM insertManagervm)
        {
            return Ok(accountRepository.SetManager(insertManagervm));
        }


      





    }


}
