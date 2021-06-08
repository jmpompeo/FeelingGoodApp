using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Services.Models
{
    public class ExerciseRequest
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public string Gender { get; set; }
        public string WeightKg { get; set; }
        public string HeightCm { get; set; }
        public string Age { get; set; }
    }
}
