using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeelingGoodApp.Models;
using System.Net.Http.Json;
using FeelingGoodApp.Data.Models;
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

        public NutritionService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<UserNutrition> GetName()
        {
            return await _client.GetFromJsonAsync<UserNutrition>("/v2/natural/nutrients");
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

        private ExerciseRequest MapUserProfileToExerciseRequest(UserProfileViewModel profile)
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


    }
}
