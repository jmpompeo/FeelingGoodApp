using FeelingGoodApp.Services.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public class LocationService : ILocationService
    {

        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private string GoogleApiKey => _configuration["GoogleApiKey"];

        public LocationService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<Location> GetLocationAsync(string address)
        {
            var locationBaseUrl = "https://maps.googleapis.com/maps/api";
            var locationEndpoint = $"/geocode/json?address={address}&key={GoogleApiKey}";

            var response = await _httpClient.GetAsync(locationBaseUrl + locationEndpoint);
            
            var results = await response.Content.ReadAsStringAsync(); // returns a string of Json Data

            JObject jsonObject = JObject.Parse(results); // Represents JSON Data as an Object

            if (jsonObject["status"].ToString() == "ZERO_RESULTS")
            {
                return null;
            }

            if (jsonObject["results"].Count() < 1)
            {
                return null;
            }

            JArray jArray = (JArray)jsonObject["results"]; // Access's the "results" property of the JObject which is a collection, which it why who use a JArray

            Location location = new Location
            {
                Latitude = (float)jArray[0]["geometry"]["location"]["lat"], // we access the first index of the array, and the "Children" properties chained together
                Longitude = (float)jArray[0]["geometry"]["location"]["lng"]
            };

            return location; // you can put a breakpoin here to test 
        }

        public async Task<IList<Place>> GetPlacesAsync(Location location, int radius, string type)
        {
            var baseUrl = "https://maps.googleapis.com/maps/api/";
            //var radius = 50000;
            //var types = "gym";

            var endpoint = $"place/nearbysearch/json?location={location.Latitude},{location.Longitude}&radius={radius}&keyword={type}&key={GoogleApiKey}";

            var response = await _httpClient.GetFromJsonAsync<PlacesResponse>(baseUrl + endpoint);


            return response.results;
        }

        public async Task<object> GetFitnessAsync(string latitude, string longitude)
        {
            var endpoint = $"geocode/something";
            var queryParameters = $"?location={latitude},{longitude}&key={GoogleApiKey}";

            var url = _httpClient.BaseAddress + endpoint + queryParameters;

            var results = await _httpClient.GetFromJsonAsync<object>(url);

            return results;
        }
    }
}
