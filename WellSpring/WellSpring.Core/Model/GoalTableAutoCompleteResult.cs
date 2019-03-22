using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class GoalTableAutoCompleteResult
    {
        public string Id { get; set; }
        [JsonProperty("UserID")]
        public string UserID { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Detail")]
        public string Detail { get; set; }
        [JsonProperty("Completed")]
        public bool Completed { get; set; }
        [JsonProperty("Start")]
        public DateTime Start { get; set; }
        [JsonProperty("Finish")]
        public DateTime Finish { get; set; }
    }
}
