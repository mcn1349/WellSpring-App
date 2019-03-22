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
    public class FoodEnteredTableDatabase : IFoodEnteredTableDatabase
    {
        private SQLiteConnection database;

        public FoodEnteredTableDatabase()
        {
            ISqlite sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<FoodEnteredTable>();
        }
        public async Task<bool> CheckIfExists(FoodEnteredTableAutoCompleteResult food)
        {
            return await CheckIfExists(new FoodEnteredTable(food));
        }

        public async Task<bool> CheckIfExists(FoodEnteredTable food)
        {
            var exist = database.Table<FoodEnteredTable>().Any(x => x.Id == food.Id);
            return exist;
        }

        public async Task<IEnumerable<FoodEnteredTable>> GetConnection()
        {
            return database.Table<FoodEnteredTable>().ToList();
        }

        public async Task<int> InsertFood(FoodEnteredTableAutoCompleteResult food)
        {
            return await InsertFood(new FoodEnteredTable(food));
        }

        public async Task<int> InsertFood(FoodEnteredTable food)
        {
            var num = database.Insert(food);
            database.Commit();
            return num;
        }
        public Task<IEnumerable<FoodEnteredTable>> GetFood()
        {
            return null;
        }

        public Task<int> DeleteFood(object id)
        {
            return null;
        }
    }
}