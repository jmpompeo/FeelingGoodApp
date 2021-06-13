﻿using FeelingGoodApp.Data;
using FeelingGoodApp.Data.Models;
using FeelingGoodApp.Models;
using FeelingGoodApp.Services;
using FeelingGoodApp.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILocationService _locationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FeelingGoodContext _context;

        public HomeController(INutritionService service, ILocationService locationService, UserManager<ApplicationUser> userManager, FeelingGoodContext context)
        {
            _service = service;
            _locationService = locationService;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            //var userId = _userManager.GetUserId(User);
            //return View(await _context.EndUser.FirstOrDefaultAsync(x => x.Id == userId)); // need to figure out how to get it to work with Id
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string Item_Name)
        {
            var information = await _service.GetFieldsAsync(Item_Name);
            NutritionViewModel FoodChoice = new NutritionViewModel(information.hits.FirstOrDefault().fields.item_name, information.hits.FirstOrDefault().fields.nf_calories, information.hits.FirstOrDefault().fields.nf_serving_size_qty);
            //var response = information.hits.FirstOrDefault().fields.nf_calories;
            return View(FoodChoice);
        }



        public async Task<IActionResult> GetLongLat(int zipCode)
        {

            //var getZip = await _userManager.Users.Where(x => x.ZipCode == zipCode);

            var location = await _locationService.GetLocationAsync(zipCode);

            var places = await _locationService.GetPlacesAsync(location);

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

