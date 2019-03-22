using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class GoalTable : EntityData
    {
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool Completed { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
    }
}