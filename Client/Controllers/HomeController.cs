using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Employee")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Employee")]
        public IActionResult Content()
        {
            return View("Content");
        }

        [Authorize(Roles = "Employee")]
        public IActionResult Latihan()
        {
            return View("Latihan");
        }

        public IActionResult ShowEmployee()
        {
            return View("ShowEmployee");
        }

        [Authorize(Roles = "Employee")]
        public IActionResult LatihanChart()
        {
            return View("LatihanChart");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
