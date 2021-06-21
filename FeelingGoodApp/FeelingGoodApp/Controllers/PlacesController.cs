using FeelingGoodApp.Models;
using FeelingGoodApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Controllers
{
    public class PlacesController : Controller
    {
        private readonly ILocationService _locationService;

        public PlacesController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public IActionResult SearchPlaces()
        {

            return View();
        }

        public async Task<IActionResult> GetPlaces(string address, int radius, string type) 
        {
            if (string.IsNullOrEmpty(address))
            {
                return View(nameof(SearchPlaces), new IndexViewModel { ErrorMessage = "Address cannot be empty" });
                //return BadRequest("Address cannot be empty");
            }
          
            var location = await _locationService.GetLocationAsync(address);

            if (location is null)
            {
                return View(nameof(SearchPlaces), new IndexViewModel { ErrorMessage = $"Sorry, unable to find a location with the address: \"{address}\" provided." });
                // return NotFound($"Sorry, unable to find a location with the address: \"{address}\" provided.");
            }

            var places = await _locationService.GetPlacesAsync(location, radius, type);
            ViewData["type"] = type;
            return View(places);
        }
    }
}
