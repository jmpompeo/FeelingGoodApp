using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeelingGoodApp.Data
{
    public class ApplicationUser : IdentityUser
    {

        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }
        public double GoalWeight { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public int Age { get; set; }
    }
}
