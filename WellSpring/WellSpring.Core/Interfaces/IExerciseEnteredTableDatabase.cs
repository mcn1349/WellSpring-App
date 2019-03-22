using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IExerciseEnteredTableDatabase
    {
        Task<IEnumerable<ExerciseEnteredTable>> GetConnection();

        Task<int> InsertExercise(ExerciseEnteredTable exercise);
        Task<int> InsertExercise(ExerciseEnteredTableAutoCompleteResult exercise);

        Task<bool> CheckIfExists(ExerciseEnteredTable exercise);
        Task<bool> CheckIfExists(ExerciseEnteredTableAutoCompleteResult exercise);

        Task<IEnumerable<ExerciseEnteredTable>> GetExercise();
    }
}