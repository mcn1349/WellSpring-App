using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class ConsultTable : EntityData
    {

        public string NurseID { get; set; } 
        public string PatientID { get; set; }
        public string Question { get; set; }
        public string Detail { get; set; }

    }
}