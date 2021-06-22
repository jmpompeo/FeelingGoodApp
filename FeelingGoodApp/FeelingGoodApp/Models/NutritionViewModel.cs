using FeelingGoodApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace FeelingGoodApp.Models
{
    public class NutritionViewModel
    {
        public NutritionViewModel(string name, double calories, int quantity)
        {
            item_name = name;
            nf_calories = calories;
            Quantity = quantity;
        }
        public NutritionViewModel()
        {

        }

        [Key]
        public int Id { get; set; }
        public string item_name { get; set; }
        public double nf_calories { get; set; }
        public int Quantity { get; set; }
    }
}
