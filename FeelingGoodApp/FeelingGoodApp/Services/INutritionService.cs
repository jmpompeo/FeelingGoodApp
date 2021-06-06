using FeelingGoodApp.Data.Models;
using FeelingGoodApp.Models;
using FeelingGoodApp.Services.Models;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public interface INutritionService
    {
        Task<UserNutrition> GetName();
        Task<ExerciseInfo> GetExercise(string exercise);
    }
}