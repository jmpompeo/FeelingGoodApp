using nutrition.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace nutrition.Models
{
    public class NutritionViewModel
    {
        public NutritionViewModel(string name, float calories, int quantity)
        {
            item_name = name;
            nf_calories = calories;
            Quantity = quantity;
        }
        public NutritionViewModel()
        {

        }

        public string item_name { get; set; }
        public float nf_calories { get; set; }
        public int Quantity { get; set; }
    }
}
