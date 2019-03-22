using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class ConsultTable
    {
        public ConsultTable() { }
        public ConsultTable(ConsultTableAutoCompleteResult consult)
        {
            Question = consult.Question;
            Detail = consult.Detail;
            PatientID = consult.PatientID;
            NurseID = consult.NurseID;
        }
        public string Id { get; set; }
        public string Question { get; set; } // allowed to be null
        public string Detail { get; set; } // allowed to be null
        public string PatientID { get; set; } // allowed to be null
        public string NurseID { get; set; } // allowed to be null

    }
}
