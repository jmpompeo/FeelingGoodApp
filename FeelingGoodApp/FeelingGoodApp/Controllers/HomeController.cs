using FeelingGoodApp.Data;
using FeelingGoodApp.Models;
using FeelingGoodApp.Services;
using FeelingGoodApp.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeelingGoodApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly INutritionService _service;
        private readonly IConfiguration _configuration;
        private readonly ILocationService _locationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FeelingGoodContext _context;

        public HomeController(INutritionService service, ILocationService locationService, UserManager<ApplicationUser> userManager, FeelingGoodContext context, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
            _locationService = locationService;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string item_Name)
        {
            
            var information = await _service.GetFieldsAsync(item_Name);
            NutritionViewModel FoodChoice = new NutritionViewModel(information.hits.FirstOrDefault().fields.item_name, information.hits.FirstOrDefault().fields.nf_calories, information.hits.FirstOrDefault().fields.nf_serving_size_qty);
            //var response = information.hits.FirstOrDefault().fields.nf_calories;
            return View(FoodChoice); // need to add the ability to edit the quantity
        }

        public async Task<IActionResult> GetPlaces(string address, int radius, string type)
        {
            var location = await _locationService.GetLocationAsync(address);

            var places = await _locationService.GetPlacesAsync(location, radius, type);
            ViewData["type"] = type;
            return View(places);
        }

        //public async Task<IActionResult> ShowMeal()
        //{
        //    var response = await _service.GetName();
        //    return View(response.Breakfast);
        //}

        [HttpPost]
        public async Task<IActionResult> ShowExercise(UserProfileViewModel profile)
        {
            
            var activity = await _service.GetExercise(profile);
            return View(activity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.MealData.FindAsync(id);
            return View(food);
        }

        public async Task<IActionResult> AddToMeals(NutritionViewModel Meal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Meal);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NutritionViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (id != model.Id)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

       // [HttpPost]
       //public async Task<IActionResult> EditExercise(UserProfileViewModel profile)
       // {

       //     var edit = await _service.
       // }

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

