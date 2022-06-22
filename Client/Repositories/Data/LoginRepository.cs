using API.ViewModel;
using Client.Base;
using Client.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class LoginRepository
    {
        //private  Address address;
        private readonly HttpClient httpClient;

        private readonly IHttpContextAccessor _contextAccessor;
        public LoginRepository() {
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44360/api/")
            };


        }

        public async Task<JWTokenVM> Auth(LoginPegawaiVM login)
        {
            JWTokenVM token = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync("Account/login", content);

            string apiResponse = await result.Content.ReadAsStringAsync();
            token = JsonConvert.DeserializeObject<JWTokenVM>(apiResponse);

            return token;
        }
    }
}
