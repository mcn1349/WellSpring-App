using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class ExerciseEnteredTableAutoCompleteResult
    {
        [PrimaryKey, AutoIncrement]

        public string Id { get; set; }
        [JsonProperty("UserID")]
        public string UserID { get; set; }
        [JsonProperty("ExerciseID")]
        public string ExerciseID { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
    }
}
