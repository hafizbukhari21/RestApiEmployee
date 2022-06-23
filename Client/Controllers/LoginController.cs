﻿using API.ViewModel;
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


        [Authorize(Roles = "Employee")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Loginpage")]
        public IActionResult LoginPage()
        {
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
                HttpContext.Session.SetString("Email", login.email);
            }
            return Json(result);

        }
        [HttpGet]
        public void Logout()
        {
            HttpContext.Session.Remove("JWToken");

            HttpContext.Response.Redirect("/LoginPage");
        }


    }
}
