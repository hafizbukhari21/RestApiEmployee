using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using System.Threading.Tasks;
using Client.Base;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using API.ViewModel;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Client.Repositories.Data
{
    public class EmployeeRepository:GeneralRepository<Employee, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public EmployeeRepository(Address address, string request = "Employees/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }

        public async Task<List<Object>> GetCustom()
        {
            List<Object> entities = new List<Object>();
            using (var response = await httpClient.GetAsync("baseController/EmployeeControllerV2/GetRegisterData"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<Object>>(apiResponse);
            }
            return entities;
        }


        public async Task<Object> GetCustom(string id)
        {
            Object entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<Object>(apiResponse);
            }
            return entity;
        }

        public HttpStatusCode PostCustom(RegisterPegawaiVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("baseController/EmployeeControllerV2/register", content).Result;
            return result.StatusCode;
        }

        public HttpStatusCode DeleteCustom(string id)
        {
            var result = httpClient.DeleteAsync("baseController/EmployeeControllerV2/DeleteAlternative?nik=" + id).Result;
            return result.StatusCode;
        }

        public HttpStatusCode PatchCustom(Employee entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("baseController/EmployeeControllerV2/withPost", content).Result;
            return result.StatusCode;
        }

    }
}
