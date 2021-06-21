using System.ComponentModel.DataAnnotations;

namespace FeelingGoodApp.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        public double Weight { get; set; }

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

        public ApplicationUser User { get; set; }
    }
}
