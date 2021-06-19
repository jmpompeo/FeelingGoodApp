using FeelingGoodApp.Models;
using FeelingGoodApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Controllers
{
    public class NutritionController : Controller
    {
        private readonly INutritionService _service;
        // GET: NutritionController

        public NutritionController(INutritionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Search(string item_Name)
        {
            var information = await _service.GetFieldsAsync(item_Name);
            NutritionViewModel FoodChoice = new NutritionViewModel(information.hits.FirstOrDefault().fields.item_name, information.hits.FirstOrDefault().fields.nf_calories, information.hits.FirstOrDefault().fields.nf_serving_size_qty);
            //var response = information.hits.FirstOrDefault().fields.nf_calories;
            return View(FoodChoice); // need to add the ability to edit the quantity
        }
        public IActionResult GetNutrition()
        {

            return View();
        }

        //[HttpPost]


        // GET: NutritionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NutritionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NutritionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Search));
            }
            catch
            {
                return View();
            }
        }

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
                return RedirectToAction(nameof(Search));
            }
            catch
            {
                return View();
            }
        }

        // GET: NutritionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NutritionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Search));
            }
            catch
            {
                return View();
            }
        }
    }
}
