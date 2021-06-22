using FeelingGoodApp.Data;
using FeelingGoodApp.Data.Models;
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


        public ExerciseController(IExerciseService service, FeelingGoodContext context, UserManager<ApplicationUser> usermanager)
        {
            _service = service;
            _context = context;
            _usermanager = usermanager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _usermanager.GetUserId(User);
            return View(await _context.Exercises.Where(x => x.User.Id == userId).ToListAsync());
        }

        public IActionResult GetExercise()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowExercise(UserProfileViewModel model)
        {
            var exercise = new ExerciseViewModel();
            var information = await _service.GetExercise(model);
            var exr = new Exercise();
            var user = await _usermanager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                exr.Pace = information.Met;
                exr.Calories = information.Nf_calories;
                exr.Duration = information.Duration_min;
                exr.User = user;

                exercise.Pace = exr.Pace;
                exercise.Calories = exr.Calories;
                exercise.Duration = exr.Duration;
                exercise.Description = exr.Description;


            }
            _context.Exercises.Add(exr);
            await _context.SaveChangesAsync();
            return View(exercise); // need to add the ability to edit the quantity
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exercise = await _context.Exercises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercise == null)
            {
                return NotFound();
            }
            return View(exercise);
        }
        //added GET create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //added Post Create and Bind to protect against overposting attacks
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,User")] ExerciseInfo exercise)
        {
            if (ModelState.IsValid)
            {
                exercise.User = await _usermanager.GetUserAsync(User);
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercise);
        }
        // Get Exercise Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return View(exercise);
        }
        // Added POST Exercise Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,User")] ExerciseViewModel exercise)
        {
            if (id != exercise.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseExists(exercise.Id))
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
            return View(exercise);
        }
        //Added Get Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var toDo = await _context.Exercises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }
        //Added Post Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Exercises = await _context.Exercises.FindAsync(id);
            _context.Exercises.Remove(Exercises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.Id == id);
        }
    }
}
