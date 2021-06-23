using FeelingGoodApp.Data;

namespace FeelingGoodApp.Services.Models
{
    public class ExerciseInfo
    {

        public int Id { get; set; }
        public string User_input { get; set; }
        public double Duration_min { get; set; }
        public double Met { get; set; }
        public double Nf_calories { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ExerciseInfo[] exercises { get; set; }
        public ApplicationUser User { get; set; }
    }
}
