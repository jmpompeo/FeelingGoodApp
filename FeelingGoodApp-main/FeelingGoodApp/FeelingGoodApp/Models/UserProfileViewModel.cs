using FeelingGoodApp.Data;

namespace FeelingGoodApp.Models

{
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        public string query { get; set; }
        public string gender { get; set; }
        public float weight_kg { get; set; }
        public float height_cm { get; set; }
        public int age { get; set; }
    }
}