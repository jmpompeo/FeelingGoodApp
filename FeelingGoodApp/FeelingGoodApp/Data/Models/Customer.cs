using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double GoalWeight { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
    }
}
