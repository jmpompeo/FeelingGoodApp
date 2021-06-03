using FeelingGoodApp.Models;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public interface INutritionService
    {
        Task<UserNutrition> GetName();
    }
}