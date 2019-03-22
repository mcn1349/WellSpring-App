using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class ConsultTableAutoCompleteResult
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        [JsonProperty("Question")]
        public string Question { get; set; }
        [JsonProperty("Detail")]
        public string Detail { get; set; }
        [JsonProperty("PatientID")]
        public string PatientID { get; set; }
        [JsonProperty("NurseID")]
        public string NurseID { get; set; }


    }
}
