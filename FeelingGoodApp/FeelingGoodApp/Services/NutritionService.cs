using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelingGoodApp.Models;
using System.Net.Http.Json;
using FeelingGoodApp.Data.Models;
using FeelingGoodApp.Services.Models;

namespace FeelingGoodApp.Services
{
    public class NutritionService : INutritionService
    {
        private readonly HttpClient _client;
        public NutritionService(HttpClient client)
        {
            _client = client;
        }

        [HttpPost]
        public async Task<UserNutrition> GetName()
        {
            return await _client.GetFromJsonAsync<UserNutrition>("/v2/natural/nutrients");
        }

        [HttpPost]
        public async Task<ExerciseInfo> GetExercise(string exercise)
        {
            var response = await _client.PostAsJsonAsync($"/v2/natural/exercise", new ExerciseRequest { query = exercise, gender = "male", weight_kg = 72, age = 30, height_cm = 167 });
            //response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ExerciseInfo>();
        }
    }
}
