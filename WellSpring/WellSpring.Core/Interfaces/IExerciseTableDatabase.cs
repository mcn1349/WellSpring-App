using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IExerciseTableDatabase
    {
        Task<IEnumerable<ExerciseTable>> GetConnection();

        Task<int> InsertExercise(ExerciseTable exercise);
        Task<int> InsertExercise(ExerciseTableAutoCompleteResult Exercise);

        Task<bool> CheckIfExists(ExerciseTable Exercise);
        Task<bool> CheckIfExists(ExerciseTableAutoCompleteResult exercise);
        Task<IEnumerable<ExerciseTable>> GetExercise();
    }
}
