using FeelingGoodApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FeelingGoodApp.Services.Models;

namespace FeelingGoodApp.Services.Models
{
    public class FeelingGoodContext : IdentityDbContext
    {
        public FeelingGoodContext(DbContextOptions<FeelingGoodContext> options)
            : base(options)
        {
        }

        public DbSet<ExerciseRequest> EndUser { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<FeelingGoodApp.Services.Models.ExerciseInfo> ExerciseInfo { get; set; }
        public DbSet<FeelingGoodApp.Services.Models.ExerciseResponse> ExerciseResponse { get; set; }
    }
}
