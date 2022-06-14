using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class TestCors : Controller
    {
        [HttpGet("TestCors")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("TestAmmet")]
        public IActionResult TestAmmet()
        {
            return View();
        }
    }
}
