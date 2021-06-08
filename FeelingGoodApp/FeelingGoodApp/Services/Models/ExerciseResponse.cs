using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FeelingGoodApp.Services.Models
{
    public class ExerciseResponse
    {
        public int Id { get; set; }

        [JsonPropertyName("exercises")]
        public IList<ExerciseInfo> Exercises { get; set; }
    }
}
