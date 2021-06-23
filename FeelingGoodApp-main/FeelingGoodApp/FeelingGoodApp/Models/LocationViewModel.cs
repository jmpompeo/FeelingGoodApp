using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Models
{
    public class LocationViewModel
    {

        public LocationViewModel(string name, string formattedAddress, float rating)
        {
            Name = name;
            FormattedAddress = formattedAddress;
            Rating = rating;
        }
        public LocationViewModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FormattedAddress { get; set; }
        public float Rating { get; set; }
        
    }
}
