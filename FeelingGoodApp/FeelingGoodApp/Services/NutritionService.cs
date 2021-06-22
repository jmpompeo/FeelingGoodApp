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
        
        private string NutritionAPIKey2 => _configuration["NutritionAPIKey2"];

        public NutritionService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        
        public async Task<NutritionFactsResults> GetFieldsAsync(string item_name)
        {
            var response = await _client.GetAsync($"v2/search/instant?query={itemName}");
            var results = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<NutritionFactsResults>(await response.Content.ReadAsStringAsync());
            // return await _client.GetFromJsonAsync<NutritionFactsResults>($"v1_1/search/{item_name}?fields=item_name%2Citem_id%2Cbrand_name%2Cnf_calories");
        }

        public Task<UserNutrition> GetName()
        {
            throw new System.NotImplementedException();
        }
    }
}

