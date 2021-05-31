using FeelingGoodApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeelingGoodApp.Data
{
    public class FeelingGoodContext : IdentityDbContext
    {
        public FeelingGoodContext(DbContextOptions<FeelingGoodContext> options)
            : base(options)
        {
        }

        public DbSet<User> EndUser { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
    }
}
