using nutrition.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using static nutrition.Services.Models.NutritionFactsResults;

namespace nutrition.Services
{
    public class NutritionService : INutritionService
    {
        private readonly HttpClient _client;
        public NutritionService(HttpClient client)
        {
            _client = client;
        }
        public async Task<NutritionFactsResults> GetFieldsAsync(string item_name)
        {
            return await _client.GetFromJsonAsync<NutritionFactsResults>($"v1_1/search/{item_name}?fields=item_name%2Citem_id%2Cbrand_name%2Cnf_calories");
        }
    }
            


    
}
