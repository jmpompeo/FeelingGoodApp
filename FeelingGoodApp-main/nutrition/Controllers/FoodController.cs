using Microsoft.AspNetCore.Mvc;
using nutrition.Models;
using nutrition.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nutrition.Controllers
{
    public class FoodController : Controller
    {
        private readonly INutritionService _service;
        public FoodController(INutritionService service)

        {
            _service = service;
        }
        public IActionResult Index()
        {
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
    }
}
