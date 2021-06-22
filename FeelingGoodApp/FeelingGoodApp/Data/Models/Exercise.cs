using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Data.Models
{
    public class Exercise
    {
        [Key]
        public int? Id { get; set; }

        public double Duration { get; set; }

        public double Pace { get; set; }

        public double Calories { get; set; }

        public string Description { get; set; }

        public ApplicationUser User { get; set; }
    }

 
}
