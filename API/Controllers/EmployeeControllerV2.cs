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

namespace API.Controllers
{
    
    [ApiController]
    public class EmployeeControllerV2 : BaseController<Employee,EmployeeRepository,string>
    {

        public EmployeeRepository employeeRepository;
        private ResponseFormatter responseFormatter = new ResponseFormatter();
        public EmployeeControllerV2(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
           
        }


        [HttpPost("register")]
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
        [HttpPost("GetRegisterData")]
        public ActionResult GetRegisterData()
        {
            return Ok(employeeRepository.GetRegisterData());
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
