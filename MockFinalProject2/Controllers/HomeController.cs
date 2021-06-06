using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockFinalProject2.Models;
using MockFinalProject2.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MockFinalProject2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INutritionService _service; 

        public HomeController(ILogger<HomeController> logger, INutritionService service)
        {
            _logger = logger;
            _service = service;
        }
        public async Task<IActionResult> ShowMeal()
        {
            var response = await _service.GetName();
            return View(response.Breakfast);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
