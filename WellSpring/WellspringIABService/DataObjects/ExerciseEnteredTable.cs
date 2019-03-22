using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class ExerciseEnteredTable : EntityData
    {

        public string UserID { get; set; }
        public string ExerciseID { get; set; }
        public DateTime Date { get; set; }
    }
}