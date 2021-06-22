using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Data.Models
{
    public class Nutrition
    {
        public Nutrition(string name, double calories, int quantity)
        {
            Item_name = name;
            Nf_calories = calories;
            Quantity = quantity;
        }
        public Nutrition()
        {

        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Item Name")]
        [Required]
        public string Item_name { get; set; }

        [Display(Name = "Calories")]
        public double Nf_calories { get; set; }

        [Required]
        public int Quantity { get; set; }
        public ApplicationUser User { get; set; }

    }
}
