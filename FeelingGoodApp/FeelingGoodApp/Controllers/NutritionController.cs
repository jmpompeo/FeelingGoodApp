using FeelingGoodApp.Data;
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
            return View(nutritionModel); // need to add the ability to edit the quantity
        }

        public async Task<IActionResult> Index()
        {
            var userId = _usermanager.GetUserId(User);
            return View(await _context.MealData.Where(x => x.User.Id == userId).ToListAsync());
        }

        public IActionResult AddFood()
        {

            return View();
        }

        //public async Task<IActionResult> AddToMeals(NutritionViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _usermanager.GetUserAsync(User);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));

        //    }

        //    return View(model);
        //}



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
                return RedirectToAction(nameof(GetNutrition));
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
                    if (!FoodExists(model.Id))
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
                return RedirectToAction(nameof(GetNutrition));
            }
            catch
            {
                return View();
            }
        }
        private bool FoodExists(int id)
        {
            return _context.MealData.Any(e => e.Id == id);
        }
    }
}
