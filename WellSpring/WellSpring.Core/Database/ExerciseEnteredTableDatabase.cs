using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.Database
{
    public class ExerciseEnteredTableDatabase : IExerciseEnteredTableDatabase
    {
        private SQLiteConnection database;

        public ExerciseEnteredTableDatabase()
        {
            ISqlite sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<ExerciseEnteredTable>();
        }
        public async Task<bool> CheckIfExists(ExerciseEnteredTableAutoCompleteResult exercise)
        {
            return await CheckIfExists(new ExerciseEnteredTable(exercise));
        }

        public async Task<bool> CheckIfExists(ExerciseEnteredTable exercise)
        {
            var exist = database.Table<ExerciseEnteredTable>().Any(x => x.Id == exercise.Id);
            return exist;
        }

        public async Task<IEnumerable<ExerciseEnteredTable>> GetConnection()
        {
            return database.Table<ExerciseEnteredTable>().ToList();
        }

        public async Task<int> InsertExercise(ExerciseEnteredTableAutoCompleteResult exercise)
        {
            return await InsertExercise(new ExerciseEnteredTable(exercise));
        }

        public async Task<int> InsertExercise(ExerciseEnteredTable exercise)
        {
            var num = database.Insert(exercise);
            database.Commit();
            return num;
        }
        public Task<IEnumerable<ExerciseEnteredTable>> GetExercise()
        {
            return null;
        }
    }
}