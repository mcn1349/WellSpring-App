using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class GoalTable
    {
        public GoalTable() { }
        public GoalTable(GoalTableAutoCompleteResult goal)
        {
            UserID = goal.UserID;
            Title = goal.Title;
            Detail = goal.Detail;
            Completed = goal.Completed;
            Start = goal.Start;
            Finish = goal.Finish;
        }

        public string Id { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public bool Completed { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        
    }
}
