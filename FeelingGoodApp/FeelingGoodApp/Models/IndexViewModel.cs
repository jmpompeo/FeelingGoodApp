using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeelingGoodApp.Models
{
    public class IndexViewModel
    {
        //public IndexViewModel(string name, string address, int radius, string type, string query, int age, float height_cm, float weight_kg, string gender)
        //{
        //    item_name = name;
        //    Address = address;
        //    Radius = radius;
        //    Type = type;
        //    Query = query;
        //    Age = age;
        //    Height_cm = height_cm;
        //    Weight_kg = weight_kg;
        //    Gender = gender;
        //    Query = query;
        //}
        public IndexViewModel()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string item_name { get; set; }
        public string Address { get; set; }
        public int Radius { get; set; }
        public string Type { get; set; }
        public string Query { get; set; }
        public string Gender { get; set; }
        public float Weight_kg { get; set; }
        public float Height_cm { get; set; }
        public int Age { get; set; }
        public string ErrorMessage { get; set; }
    }
}
