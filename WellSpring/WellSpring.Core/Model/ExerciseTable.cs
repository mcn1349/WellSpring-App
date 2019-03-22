using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class ExerciseTable
    {
        public ExerciseTable() { }
        public ExerciseTable(ExerciseTableAutoCompleteResult exercise)
        {
            ExerciseType = exercise.ExerciseType;
            Name = exercise.Name;
            Distance = exercise.Distance;
            Laps = exercise.Laps;
            Sets = exercise.Sets;
            Duration = exercise.Duration;
            Calories = exercise.Calories;
        }
        public string Id { get; set; }

        public string ExerciseType { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }
        public int Laps { get; set; }
        public int Sets { get; set; }
        public int Duration { get; set; }
        public int Calories { get; set; }

    }
}
