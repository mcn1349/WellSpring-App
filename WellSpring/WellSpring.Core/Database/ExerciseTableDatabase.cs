using MvvmCross.Platform;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.Database
{
    public class ExerciseTableDatabase : IExerciseTableDatabase
    {
        private SQLiteConnection database;

        public ExerciseTableDatabase()
        {
            ISqlite sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<ExerciseTable>();
        }
        public async Task<bool> CheckIfExists(ExerciseTableAutoCompleteResult exercise)
        {
            return await CheckIfExists(new ExerciseTable(exercise));
        }

        public async Task<bool> CheckIfExists(ExerciseTable exercise)
        {
            var exist = database.Table<ExerciseTable>().Any(x => x.Id == exercise.Id);
            return exist;
        }
        
        public async Task<IEnumerable<ExerciseTable>> GetConnection()
        {
            return database.Table<ExerciseTable>().ToList();
        }

        public Task<IEnumerable<ExerciseTable>> GetExercise()
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertExercise(ExerciseTable exercise)
        {
            return null;
        }

        public async Task<int> InsertExercise(ExerciseTableAutoCompleteResult exercise)
        {
            return await InsertExercise(new ExerciseTable(exercise));
        }
        
    }
}
