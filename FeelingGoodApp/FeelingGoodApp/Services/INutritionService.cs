using FeelingGoodApp.Data.Models;
using FeelingGoodApp.Models;
using FeelingGoodApp.Services.Models;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public interface INutritionService
    {
<<<<<<< HEAD
        Task<UserNutrition> GetName();
=======
       Task<NutritionFactsResults> GetFieldsAsync(string item_name);

>>>>>>> fc26f106d04073438c3aae6dd2c0c72dcef6e41e
        Task<ExerciseInfo> GetExercise(UserProfileViewModel profile);
    }
}