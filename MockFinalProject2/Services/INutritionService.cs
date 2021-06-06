using MockFinalProject2.Models;
using System.Threading.Tasks;

namespace MockFinalProject2.Services
{
    public interface INutritionService
    {
        Task<UserNutrition> GetName();
    }
}