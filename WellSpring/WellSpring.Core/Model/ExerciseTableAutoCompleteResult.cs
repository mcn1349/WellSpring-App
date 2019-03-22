using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class ExerciseTableAutoCompleteResult
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }

        [JsonProperty("ExerciseType")]
        public string ExerciseType { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Distance")]
        public int Distance { get; set; }
        [JsonProperty("Laps")]
        public int Laps { get; set; }
        [JsonProperty("Sets")]
        public int Sets { get; set; }
        [JsonProperty("Duration")]
        public int Duration { get; set; }
        [JsonProperty("Calories")]
        public int Calories { get; set; }

    }
}
