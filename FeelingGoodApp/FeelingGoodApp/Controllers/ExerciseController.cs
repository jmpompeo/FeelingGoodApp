using FeelingGoodApp.Models;
using FeelingGoodApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly INutritionService _service;
       

        public ExerciseController(INutritionService service)
        {
            _service = service;
        }

        public IActionResult GetExercise()
        {
            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> ShowExercise(UserProfileViewModel profile)
        {

            var activity = await _service.GetExercise(profile);


            return View(activity);
        }
    }
}
