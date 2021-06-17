using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelingGoodApp.Models;
using System.Net.Http.Json;
using FeelingGoodApp.Services.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace FeelingGoodApp.Services
{
    public class NutritionService : INutritionService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private string NutritionAPIKey => _configuration["NutritionAPIKey"];
        private string NutritionAPIKey2 => _configuration["NutritionAPIKey2"];

        public NutritionService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ExerciseInfo> GetExercise(UserProfileViewModel profile)
        {
            var exerciseRequest = MapUserProfileToExerciseRequest(profile);

            var content = new Dictionary<string, string>
            {
                { "query", exerciseRequest.Query },
                { "gender", exerciseRequest.Gender },
                { "weight_kg", exerciseRequest.WeightKg },
                { "height_cm", exerciseRequest.HeightCm },
                { "age" , exerciseRequest.Age }
            };

            var query = new FormUrlEncodedContent(content);

            var response = await _client.PostAsync($"v2/natural/exercise", query);
            //response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadFromJsonAsync<ExerciseResponse>();

            return results.Exercises.First();
        }

        public ExerciseRequest MapUserProfileToExerciseRequest(UserProfileViewModel profile)
        {
            return new ExerciseRequest
            {
                Query = profile.query,
                Gender = profile.gender,
                WeightKg = profile.weight_kg.ToString(),
                HeightCm = profile.height_cm.ToString(),
                Age = profile.age.ToString()
            };
        }
        public async Task<NutritionFactsResults> GetFieldsAsync(string item_name)
        {
            return await _client.GetFromJsonAsync<NutritionFactsResults>($"v1_1/search/{item_name}?fields=item_name%2Citem_id%2Cbrand_name%2Cnf_calories");
        }

        //public async Task<>
    }
}