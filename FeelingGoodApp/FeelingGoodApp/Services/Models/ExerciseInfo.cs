﻿namespace FeelingGoodApp.Services.Models
{
    public class ExerciseInfo
    {
        public int Id { get; set; }
        public string user_input { get; set; }
        public int duration_min { get; set; }
        public int met { get; set; }
        public int nf_calories { get; set; }
        //public ExercisePhoto photo { get; set; }
        //public int compendium_code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        //public string benefits { get; set; }
        public ExerciseInfo[] exercises { get; set; }
    }
}
