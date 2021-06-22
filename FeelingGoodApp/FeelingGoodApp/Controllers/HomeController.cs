using FeelingGoodApp.Data;
using FeelingGoodApp.Data.Models;
using FeelingGoodApp.Models;
using FeelingGoodApp.Services;
using FeelingGoodApp.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Controllers
{
    public class HomeController : Controller
    {

        //private readonly INutritionService _service;
        private readonly IConfiguration _configuration;
        private readonly ILocationService _locationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FeelingGoodContext _context;

        public HomeController(/*INutritionService service*/ ILocationService locationService, IConfiguration configuration, UserManager<ApplicationUser> userManager, FeelingGoodContext context)
        {
            //_service = service;
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
        public async Task<IActionResult> GetCustomerData(CustomerViewModel model)
        {
            Customer customer = new Customer();
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                model.Weight = customer.Weight;
                model.GoalWeight = customer.GoalWeight;
                customer.User = user;
            }
            await _context.Users.AnyAsync();
            await _context.SaveChangesAsync();
            return View(model); // need to add the ability to edit the quantity
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

