namespace FeelingGoodApp.Services.Models
{
    public class ExerciseInfo
    {
        public int Id { get; set; }
        public string user_input { get; set; }
        public float duration_min { get; set; }
        public float met { get; set; }
        public float nf_calories { get; set; }
        //public ExercisePhoto photo { get; set; }
        //public int compendium_code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        //public string benefits { get; set; }
        public ExerciseInfo[] exercises { get; set; }
    }
}
