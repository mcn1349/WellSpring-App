using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class FoodEnteredTableAutoCompleteResult
    {
        [PrimaryKey, AutoIncrement]

        public string Id { get; set; }
        [JsonProperty("UserID")]
        public string UserID { get; set; }
        [JsonProperty("FoodID")]
        public string FoodID { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
    }
}
