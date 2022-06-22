using API.Models;
using API.ViewModel;
using Client.Base;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("custom/{nik}")]
        public JsonResult GetEmployeeCustom(string nik)
        {
            return Json(employeeRepository.GetCustom(nik));
        }

        [HttpGet("custom")]
        public JsonResult GetEmployeeCustom()
        {
            return Json(employeeRepository.GetCustom());
        }

        [HttpPost("custom")]
        public JsonResult InsertEmployeeCustom(RegisterPegawaiVM registerPegawai)
        {
            return Json(employeeRepository.PostCustom(registerPegawai));
        }

        [HttpDelete("custom/{nik}")]
        public JsonResult DeleteEmployeeCustom(string nik)
        {
            return Json(employeeRepository.DeleteCustom(nik));
        }

        [HttpPatch("custom")]
        public JsonResult UpdateEmployeeCustom(Employee employee)
        {
            return Json(employeeRepository.PatchCustom(employee));
        }
    }
}
