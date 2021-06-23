using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public double Weight { get; set; }

        [Display(Name = "Goal Weight")]
        public double GoalWeight { get; set; }
    }
}
