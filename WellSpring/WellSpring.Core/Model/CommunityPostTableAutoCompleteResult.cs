using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class CommunityPostTableAutoCompleteResult
    {
        public string Id { get; set; }
        [JsonProperty("HostID")]
        public string HostID { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Image")]
        public string Image { get; set; }
    }
}
