using FeelingGoodApp.Data.Models;
using FeelingGoodApp.Models;
using FeelingGoodApp.Services.Models;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public interface INutritionService
    {
       Task<NutritionFactsResults> GetFieldsAsync(string item_name);

        Task<ExerciseInfo> GetExercise(UserProfileViewModel profile);
    }
}