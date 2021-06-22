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
        [Required]
        public double Weight { get; set; }

        [Display(Name = "Height in Centimeters")]
        public double Height { get; set; }
        
        [Display(Name = "Goal Weight")]
        [Required]
        public double GoalWeight { get; set; }

        [Display(Name = "Zip Code")]
        [Required]
        public int ZipCode { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
