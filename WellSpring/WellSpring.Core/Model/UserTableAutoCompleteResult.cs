using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class UserTableAutoCompleteResult
    {
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("AimCalorie")]
        public int AimCalorie { get; set; }
        [JsonProperty("DOB")]
        public DateTime DOB { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Weight")]
        public int Weight { get; set; }
    }
}
