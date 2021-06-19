using System.ComponentModel.DataAnnotations;

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
        public string Address { get; set; }
    }
}
