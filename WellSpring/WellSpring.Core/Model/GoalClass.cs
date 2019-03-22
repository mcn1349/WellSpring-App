using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class GoalClass
    {
        public int GoalID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public bool Completed { get; set; }
    }
}
