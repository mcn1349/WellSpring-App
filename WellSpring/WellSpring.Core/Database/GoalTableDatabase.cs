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
    public class GoalTableDatabase : IGoalTableDatabase
    {
        private SQLiteConnection database;

        public GoalTableDatabase()
        {
            ISqlite sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<GoalTable>();
        }
        public async Task<bool> CheckIfExists(GoalTableAutoCompleteResult goal)
        {
            return await CheckIfExists(new GoalTable(goal));
        }

        public async Task<bool> CheckIfExists(GoalTable goal)
        {
            var exist = database.Table<GoalTable>().Any(x => x.Id == goal.Id);
            return exist;
        }

        public async Task<IEnumerable<GoalTable>> GetConnection()
        {
            return database.Table<GoalTable>().ToList();
        }

        public async Task<int> InsertGoal(GoalTableAutoCompleteResult goal)
        {
            return await InsertGoal(new GoalTable(goal));
        }

        public async Task<int> InsertGoal(GoalTable goal)
        {
            var num = database.Insert(goal);
            database.Commit();
            return num;
        }

    }
}