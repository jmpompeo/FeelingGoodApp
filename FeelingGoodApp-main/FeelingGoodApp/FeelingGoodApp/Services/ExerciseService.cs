using FeelingGoodApp.Models;
using FeelingGoodApp.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _client;

        private string NutritionAPIKey => _configuration["NutritionAPIKey"];

        public ExerciseService(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
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
            response.EnsureSuccessStatusCode();

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
    }
}
