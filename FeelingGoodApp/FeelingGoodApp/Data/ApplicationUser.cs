using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FeelingGoodApp.Data
{
    public class ApplicationUser : IdentityUser
    {

        [PersonalData]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Goal Weight")]
        public double GoalWeight { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }
    }
}
