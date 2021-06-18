using FeelingGoodApp.Models;
using FeelingGoodApp.Services.Models;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public interface INutritionService
    {
        Task<UserNutrition> GetName();
        ExerciseRequest MapUserProfileToExerciseRequest(UserProfileViewModel profile);
        Task<NutritionFactsResults> GetFieldsAsync(string item_name);
        Task<ExerciseInfo> GetExercise(UserProfileViewModel profile);

    }
}