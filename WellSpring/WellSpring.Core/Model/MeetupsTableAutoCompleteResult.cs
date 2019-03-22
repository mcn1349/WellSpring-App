using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class MeetupsTableAutoCompleteResult
    {
        public string Id { get; set; }

        [JsonProperty("HostID")]
        public string HostID { get; set; }
        [JsonProperty("StartDateTime")]
        public DateTime StartDateTime { get; set; }
        [JsonProperty("FinishDateTime")]
        public DateTime FinishDateTime { get; set; }
        [JsonProperty("AddressName")]
        public string AddressName { get; set; }
        [JsonProperty("Longitude")]
        public double Longitude { get; set; }
        [JsonProperty("Latitude")]
        public double Latitude { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
