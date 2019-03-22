using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class JourneyTable : EntityData
    {
        public string UserID { get; set; }
        public int Calorie { get; set; }
        public DateTime Date { get; set; }
    }
}