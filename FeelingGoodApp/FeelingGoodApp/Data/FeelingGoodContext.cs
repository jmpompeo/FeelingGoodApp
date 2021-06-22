using FeelingGoodApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FeelingGoodApp.Models;
using FeelingGoodApp.Data;
using FeelingGoodApp.Services.Models;

namespace FeelingGoodApp.Services.Models
{
    public class FeelingGoodContext : IdentityDbContext<ApplicationUser>
    {
        public FeelingGoodContext(DbContextOptions<FeelingGoodContext> options)
            : base(options)
        {
        }

        public DbSet<Nutrition> MealData { get; set; }
        
        public DbSet<Exercise> Exercises { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<FeelingGoodApp.Services.Models.ExerciseInfo> ExerciseInfo { get; set; }
        
        public DbSet<FeelingGoodApp.Models.ExerciseViewModel> ExerciseViewModel { get; set; }

    }
}
