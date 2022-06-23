using API.ViewModel;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
   
    public class LoginController : Controller
    {
        private readonly LoginRepository repository;
        public LoginController(LoginRepository loginRepository)
        {
            this.repository = loginRepository;
        }


        [Authorize]
        public IActionResult Index()
        {
           
            return View();
        }

        [Route("Loginpage")]
        public IActionResult LoginPage()
        {
            if (HttpContext.Session.GetString("JWToken") != null)
            {
                return Redirect("/Login");
            }
            return View("Login");
        }

        [Route("Registerpage")]
        public IActionResult RegisterPage()
        {
            return View("Register");
        }


        [HttpPost]
        public async Task<JsonResult> Auth(LoginPegawaiVM login)
        {
            var result = await repository.Auth(login);
            if (result.idToken != null)
            {
                HttpContext.Session.SetString("JWToken", result.idToken);
                HttpContext.Session.SetString("nama", result.message);
            }
            return Json(result);

        }
        [HttpGet]
        public void Logout()
        {
            HttpContext.Session.Clear();

            HttpContext.Response.Redirect("/LoginPage");
        }


    }
}
