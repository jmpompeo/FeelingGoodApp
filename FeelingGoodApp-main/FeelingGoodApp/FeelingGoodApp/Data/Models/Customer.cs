using System.ComponentModel.DataAnnotations;

namespace FeelingGoodApp.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string query { get; set; }
        public string gender { get; set; }
        public float weight_kg { get; set; }
        public float height_cm { get; set; }
        public int age { get; set; }
        public ApplicationUser User { get; set; }
    }
}
