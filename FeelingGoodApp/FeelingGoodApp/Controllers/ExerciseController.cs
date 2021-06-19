using FeelingGoodApp.Data;
using FeelingGoodApp.Models;
using FeelingGoodApp.Services;
using FeelingGoodApp.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _service;
        private readonly FeelingGoodContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;


        public ExerciseController(IExerciseService service,FeelingGoodContext context, UserManager<ApplicationUser> usermanager)
        {
            _service = service;
            _context = context;
            _usermanager = usermanager;
        }

        public async Task<IActionResult> Index()
        {
            var userId =  _usermanager.GetUserId(User);
            return View(await _context.Exercises.Where(x => x.User.Id == userId).ToListAsync());
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
