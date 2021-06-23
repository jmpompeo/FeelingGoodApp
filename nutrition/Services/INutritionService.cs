using nutrition.Services.Models;
using System.Threading.Tasks;
using static nutrition.Services.Models.NutritionFactsResults;

namespace nutrition.Services
{
    public interface INutritionService
    {
        Task<NutritionFactsResults> GetFieldsAsync(string item_name);
    }
}