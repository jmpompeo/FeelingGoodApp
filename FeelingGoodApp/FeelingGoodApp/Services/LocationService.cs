using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _client;
        public LocationService(HttpClient client)
        {
            _client = client;
        }


    }
}
