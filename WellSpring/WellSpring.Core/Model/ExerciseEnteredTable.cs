using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class ExerciseEnteredTable
    {
        public ExerciseEnteredTable() { }
        public ExerciseEnteredTable(ExerciseEnteredTableAutoCompleteResult exercise)
        {
            UserID = exercise.UserID;
            ExerciseID = exercise.ExerciseID;
            Date = exercise.Date;
        }

        public string Id { get; set; }

        public string UserID { get; set; }
        public string ExerciseID { get; set; }
        public DateTime Date { get; set; }

    }
}
