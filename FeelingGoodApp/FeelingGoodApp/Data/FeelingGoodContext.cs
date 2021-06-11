using FeelingGoodApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FeelingGoodApp.Services.Models;
using FeelingGoodApp.Models;

namespace FeelingGoodApp.Services.Models
{
    public class FeelingGoodContext : IdentityDbContext
    {
        public FeelingGoodContext(DbContextOptions<FeelingGoodContext> options)
            : base(options)
        {
        }

        //public DbSet<ExerciseRequest> EndUser { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<ExerciseInfo> ExerciseInfo { get; set; }
        public DbSet<ExerciseResponse> ExerciseResponse { get; set; }
        public DbSet<LocationViewModel> LocationViewModel { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Customer> EndUser { get; set; }
    }
}
