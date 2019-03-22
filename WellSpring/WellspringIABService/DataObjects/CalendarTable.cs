using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class CalendarTable : EntityData
    {

        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int Calorie { get; set; }
        public int Weight { get; set; }
        public int AimWeight { get; set; }
        
    }
}