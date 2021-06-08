namespace FeelingGoodApp.Services.Models
{
    public class ExerciseInfo
    {
        public int Id { get; set; }
        //public int Tag_Id { get; set; }
        public string User_input { get; set; }
        public float Duration_min { get; set; }
        public float Met { get; set; }
        public float Nf_calories { get; set; }
        public ExercisePhoto photo { get; set; }
        public int Compendium_Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
