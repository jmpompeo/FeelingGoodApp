using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Models

{
    public class UserProfileViewModel
    {
        public string query { get; set; }
        public string gender { get; set; }
        public float weight_kg { get; set; }
        public float height_cm { get; set; }
        public int age { get; set; }
    }
}



