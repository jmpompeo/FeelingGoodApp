using FeelingGoodApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FeelingGoodApp.Models;
using FeelingGoodApp.Data;

namespace FeelingGoodApp.Services.Models
{
    public class FeelingGoodContext : IdentityDbContext<ApplicationUser>
    {
        public FeelingGoodContext(DbContextOptions<FeelingGoodContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> EndUser { get; set; }

        public DbSet<NutritionViewModel> MealData { get; set; }
        
        public DbSet<ExerciseInfo> Exercises { get; set; }
        
        public DbSet<FeelingGoodApp.Models.UserProfileViewModel> UserProfileViewModel { get; set; }
        
        //public DbSet<FeelingGoodApp.Models.UserProfileViewModel> UserProfileViewModel { get; set; }
        //public DbSet<ExerciseRequest> EndUser { get; set; }
        //public DbSet<Exercises> Exercises { get; set; }
        //public DbSet<LocationViewModel> LocationViewModel { get; set; }
        //public DbSet<Location> Location { get; set; }
        //public DbSet<IndexViewModel> IndexViewModel { get; set; }
        //public DbSet<ExerciseResponse> ExerciseResponse { get; set; }
    }
}
