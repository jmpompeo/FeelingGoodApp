using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Models
{
    public class ExerciseViewModel
    {
        public ExerciseViewModel()
        {
        }

        public ExerciseViewModel(int id, double duration, double pace, double calories, string description)
        {
            Id = id;
            Duration = duration;
            Pace = pace;
            Calories = calories;
            Description = description;
        }

        
        public int Id { get; set; }
        public double Duration { get; set; }
        public double Pace { get; set; }
        public double Calories { get; set; }
        public string Description { get; set; }
    }
}
