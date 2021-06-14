using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeelingGoodApp.Models
{
    public class IndexViewModel
    {
        public IndexViewModel(string name, string address, int radius, string type)
        {
            item_name = name;
            Address = address;
            Radius = radius;
            Type = type;
        }
        public IndexViewModel()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string item_name { get; set; }
        public string Address { get; set; }
        public int Radius { get; set; }
        public string Type { get; set; }
    }
}
