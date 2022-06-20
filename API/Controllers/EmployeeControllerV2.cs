using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repository.Data;
using API.ViewModel;
using API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;


namespace API.Controllers
{

    [ApiController]
    public class EmployeeControllerV2 : BaseController<Employee, EmployeeRepository, string>
    {

        public EmployeeRepository employeeRepository;
        public IConfiguration _configuration;
        private ResponseFormatter responseFormatter = new ResponseFormatter();
        public EmployeeControllerV2(EmployeeRepository employeeRepository, IConfiguration configuration) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this._configuration = configuration;

        }


        [HttpPost("register")]
        [EnableCors("AllowOrigin")]
        public ActionResult Register(RegisterPegawaiVM registerPegawaiVM)
        {

            if (employeeRepository.EmailIsUsed(registerPegawaiVM.Email)) return Ok("Email sudah digunakan");
            if (employeeRepository.PhoneIsUsed(registerPegawaiVM.Phone)) return Ok("No Telp sudah digunakan");
            return responseFormatter.ResponseFormater(
                 200, 400,
                 "Berhasil Menambahkan Data Baru",
                 "ID NIK duplicate atau kesalahan server",
                 employeeRepository.GetRegister(registerPegawaiVM)
             );


        }
        //[Authorize(Roles = "Direktur, Manager")]

        [HttpPost("updateUniv")]
        [EnableCors("AllowOrigin")]
        public ActionResult UpdateUniv(UpdateUnivVM updateUniv)
        {
            return Ok(employeeRepository.UpdateEducation(updateUniv));
        }

        [HttpGet("GetRegisterData")]
        public ActionResult<String> GetRegisterData()
        {
           /* var payload = JWTConfig.JwtParse(employeeRepository.GetRegisterData(), _configuration)*/;

            return Ok(employeeRepository.GetRegisterData());
        }

        [HttpGet("TestCors")]
        public ActionResult TestCors()
        {
            return Ok("Berhasil Cors");
        }

        [HttpDelete("DeleteAlternative")]
        [EnableCors("AllowOrigin")]
        public ActionResult DeleteAlter(string nik)
        {
            return Ok(employeeRepository.DeleteAlter(nik));
        }

        [HttpPost("withPost")]
        [EnableCors("AllowOrigin")]
        public ActionResult UpdateWithPost(Employee entity)
        {
            return Ok(employeeRepository.Update(entity));
        }



        //[HttpGet("mailtest")]
        //public ActionResult MailTest()
        //{
        //    EmailServices mail = new EmailServices();

        //    mail.SendEmail("hafiz.bukhari@hotmail.com", "hehe", "eeeeee");
        //    return Ok(200);
        //}




    }
}
