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

namespace API.Controllers
{
    
    [ApiController]
    public class EmployeeControllerV2 : BaseController<Employee,EmployeeRepository,string>
    {

        public EmployeeRepository employeeRepository;
        public EmployeeControllerV2(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        [HttpPost("cobaregister")]
        public ActionResult GetRegister(RegisterPegawaiVM registerPegawaiVM)
        {
            if (employeeRepository.EmailIsUsed(registerPegawaiVM.Email))
            {
                return Ok("Email sudah digunakan");
            }

            if (employeeRepository.PhoneIsUsed(registerPegawaiVM.Phone))
            {
                return Ok("No Telp sudah digunakan");
            }
            return Ok(employeeRepository.GetRegister(registerPegawaiVM));
        }


    
        
    }
}
