using FeelingGoodApp.Services.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services
{
    public interface ILocationService
    {
        Task<IList<Place>> GetPlacesAsync(Location location, int radius, string type);
        Task<Location> GetLocationAsync(string address);
        Task<object> GetFitnessAsync(string latitude, string longitude);
    }
}