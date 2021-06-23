using FeelingGoodApp.Models;
using FeelingGoodApp.Services.Models;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public interface IExerciseService
    {
        ExerciseRequest MapUserProfileToExerciseRequest(UserProfileViewModel profile);
        Task<ExerciseInfo> GetExercise(UserProfileViewModel profile);
    }
}
