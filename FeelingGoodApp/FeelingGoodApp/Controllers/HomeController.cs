using FeelingGoodApp.Models;
using FeelingGoodApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeelingGoodApp.Controllers
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
        public async Task<IActionResult> Index()
        {
            var apiKey = "AIzaSyAMovAJFRpDQRN6M1jBAg19HOl415teiNY";
            var latitude = 42.331429; //42.348495 
            var longitude = -83.045753; //-83.060303
            var radius = 5000;
            var types = "gym";
            var keyword = "gym";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "FeelingGoodApp");

            var baseUrl = "https://maps.googleapis.com/maps/api/";
            //var endpoint2 = $"place/nearbysearch/json?location=-33.8670522,151.1957362&radius=1500&type=restaurant&keyword=cruise&key={apiKey}";
            var endpoint = $"place/nearbysearch/json?location={latitude},{longitude}&radius={radius}&keyword={types}&key={apiKey}";

            var response = await client.GetAsync(baseUrl + endpoint);

            var results = await response.Content.ReadAsStringAsync(); //Here i put the BreakPoint 

            return View();
        }

        public async Task<IActionResult> ShowMeal()
        {
            var response = await _service.GetName();
            return View(response.Breakfast);
        }

        [HttpPost]
        public async Task<IActionResult> ShowExercise(string exercise)
        {
            var activity = await _service.GetExercise(exercise);
            return View(activity.exercises.First());
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

