using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repository;
using API.Models;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        private ResponseFormatter responseFormatter = new ResponseFormatter();
        public EmployeesController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 400,
                     "Berhasil Mendapatkan semua Data Pegawai",
                     "Data tidak Ditemukan",
                     employeeRepository.Get()
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }
        }

       
        [HttpGet("GetWithContainName/{name}")]
        public ActionResult GetWithContainSpesificWord(string name)
        {
            try
            {

                return responseFormatter.ResponseFormater(
                     200, 400,
                     "Data Ditemukan",
                     "Data tidak Ditemukan",
                     employeeRepository.GetWithWhere(name)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }
        }


        [HttpGet("{nik}")]
        public ActionResult GetById(string nik)
        {
            try
            { 
               return responseFormatter.ResponseFormater(
                    200, 204, 
                    "Data Ditemukan",
                    "Data tidak Ditemukan",
                    employeeRepository.Get(nik)
                );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }

        }

        [HttpPost]
        public ActionResult Post(Employee emp)
        {

            try
            {
                return responseFormatter.ResponseFormater(
                    202, 400,
                    "Data Berhasil ditambahkan !!!!",
                    "Terjadi kesalahan Pada system atau NIK Duplicate",
                    employeeRepository.Insert(emp)
                );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }
        }


        [HttpPatch]
        public ActionResult Update(Employee emp)
        {
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 400,
                     "Data Berhasil  Diupdate",
                     "Data tidak Ditemukan",
                     employeeRepository.Update(emp)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }

        }

        [HttpDelete("{nik}")]
        public ActionResult Delete(string nik)
        {
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 400,
                     "Data Berhasil  Dihapus",
                     "Data yang akan dihapus tidak ditemukan",
                     employeeRepository.Delete(nik)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data yang akan dihapus tidak ditemukan", ex, Variable.isProduction);
            }
        }




        [HttpGet("GetFirstOrDefault/{name}")]
        public ActionResult GetFirstOrDefault(string name)
        {
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 204,
                     "First Or Default, Berhasil Mendapatkan Data",
                     "Data tidak Ditemukan",
                     employeeRepository.GetFirstOrDefault(name)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }
            
        }

        [HttpGet("GetFirst/{name}")]
        public ActionResult GetFirst(string name)
        {
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 400,
                     "First , Berhasil Mendapatkan Data",
                     "Data tidak Ditemukan",
                     employeeRepository.GetFirst(name)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }

        }

        [HttpGet("GetLastOrDefault/{name}")]
        public ActionResult GetLastOrDefault(string name)
        {
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 204,
                     "Last Or Default , Berhasil Mendapatkan Data",
                     "Data tidak Ditemukan",
                     employeeRepository.GetLastOrDefault(name)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }

        }


        [HttpGet("GetLast/{name}")]
        public ActionResult GetLast(string name)
        {
         
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 204,
                     "Last , Berhasil Mendapatkan Data",
                     "Data tidak Ditemukan",
                     employeeRepository.GetLast(name)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }

        }


        [HttpGet("GetSingle/{name}")]
        public ActionResult GetSingle(string name)
        {
            
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 400,
                     "Single , Berhasil Mendapatkan Data",
                     "Data tidak Ditemukan",
                     employeeRepository.GetSingle(name)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }
        }



        [HttpGet("GetSingleOrDefault/{name}")]
        public ActionResult GetSingleOrDefault(string name)
        {
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 204,
                     "Single Or Default , Berhasil Mendapatkan Data",
                     "Data tidak Ditemukan",
                     employeeRepository.GetSingleOrDefault(name)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }
        }

        [HttpGet("GetFind/{name}")]
        public ActionResult GetFind(string name)
        {
            try
            {
                return responseFormatter.ResponseFormater(
                     200, 204,
                     "Find , Berhasil Mendapatkan Data",
                     "data tidak ada",
                     employeeRepository.GetFind(name)
                 );
            }
            catch (Exception ex)
            {
                return responseFormatter.ResponseError(400, "Data tidak ditemukan", ex, Variable.isProduction);
            }
        }
    }


  
}
