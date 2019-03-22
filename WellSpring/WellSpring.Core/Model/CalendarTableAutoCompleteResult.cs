using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class CalendarTableAutoCompleteResult
    {
        [PrimaryKey, AutoIncrement]


        public string Id { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("UserId")]
        public string UserId { get; set; }
        [JsonProperty("Calorie")]
        public int Calorie { get; set; }
        [JsonProperty("Weight")]
        public int Weight { get; set; }
        [JsonProperty("AimWeight")]
        public int AimWeight { get; set; }
        [JsonProperty("Version")]
        public int Version { get; set; }
        [JsonProperty("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("Deleted")]
        public bool Deleted { get; set; }
    }
}
