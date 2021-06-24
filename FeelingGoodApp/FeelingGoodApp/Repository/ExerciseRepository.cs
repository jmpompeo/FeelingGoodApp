using FeelingGoodApp.Data.Models;
using FeelingGoodApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Repository
{
    public class ExerciseRepository
    {
        private readonly FeelingGoodContext _db;

        public ExerciseRepository(FeelingGoodContext db)
        {
            _db = db;
        }

        public async Task<int> SaveAsync(Exercise exercise)
        {
            await _db.AddAsync(exercise);
            await _db.SaveChangesAsync();

            return exercise.Id.Value;
        }
    }
}
