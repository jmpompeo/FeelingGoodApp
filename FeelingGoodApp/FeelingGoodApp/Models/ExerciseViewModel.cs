using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Models
{
    public class ExerciseViewModel
    {
        public ExerciseViewModel(int id, float duration, float pace, float calories, string description)
        {
            Id = id;
            Duration = duration;
            Pace = pace;
            Calories = calories;
            Description = description;
        }

        public int Id { get; set; }
        public float Duration { get; set; }
        public float Pace { get; set; }
        public float Calories { get; set; }
        public string Description { get; set; }
    }
}
