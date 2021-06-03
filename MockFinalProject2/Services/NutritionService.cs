using MockFinalProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MockFinalProject2.Services
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
            
            var meal =  await _client.GetFromJsonAsync<UserNutrition>("/v2/natural/nutrients");
            return meal;
        }
    }
}
