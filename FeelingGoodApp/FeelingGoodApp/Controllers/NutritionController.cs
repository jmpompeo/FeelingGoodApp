﻿using FeelingGoodApp.Data;
using FeelingGoodApp.Data.Models;
using FeelingGoodApp.Models;
using FeelingGoodApp.Services;
using FeelingGoodApp.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Controllers
{
    public class NutritionController : Controller
    {
        private readonly INutritionService _service;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly FeelingGoodContext _context;
        // GET: NutritionController

        public NutritionController(INutritionService service, UserManager<ApplicationUser> usermanager, FeelingGoodContext context)
        {
            _service = service;
            _usermanager = usermanager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _usermanager.GetUserId(User);
            return View(await _context.MealData.Where
                (x => x.User.Id == userId).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> GetNutrition(NutritionViewModel model)
        {
            var information = await _service.GetFieldsAsync(model.item_name);
            Nutrition FoodChoice = new Nutrition();
            var nutritionModel = new NutritionViewModel();
            var user = await _usermanager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                FoodChoice.Item_name = information.hits.FirstOrDefault().fields.item_name;
                FoodChoice.Nf_calories = information.hits.FirstOrDefault().fields.nf_calories;
                FoodChoice.Quantity = information.hits.FirstOrDefault().fields.nf_serving_size_qty;
                FoodChoice.User = user;

                nutritionModel.item_name = FoodChoice.Item_name;
                nutritionModel.nf_calories = FoodChoice.Nf_calories;
                nutritionModel.Quantity = FoodChoice.Quantity;

            }
            _context.MealData.Add(FoodChoice);
            await _context.SaveChangesAsync();
            nutritionModel.Id = FoodChoice.Id;
            return View(nutritionModel); // need to add the ability to edit the quantity
        }
        public IActionResult AddFood()
        {

            return View();
        }

        // GET: NutritionController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        //// GET: NutritionController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: NutritionController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(GetNutrition));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        // GET: NutritionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NutritionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetNutrition));
            }
            catch
            {
                return View();
            }
        }

        // GET: NutritionController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.MealData.FindAsync(id);
            var model = new NutritionViewModel
            {
                Id = food.Id
            };

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: NutritionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var food = await _context.MealData.FindAsync(id);
            _context.MealData.Remove(food);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
            return _context.MealData.Any(e => e.Id == id);
        }
    }
}
