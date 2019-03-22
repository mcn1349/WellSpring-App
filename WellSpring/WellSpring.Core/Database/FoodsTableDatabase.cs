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
    public class FoodsTableDatabase : IFoodsTableDatabase
    {
        private SQLiteConnection database;

        public FoodsTableDatabase()
        {
            ISqlite sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<FoodsTable>();
        }
        public async Task<bool> CheckIfExists(FoodsTableAutoCompleteResult food)
        {
            return await CheckIfExists(new FoodsTable(food));
        }

        public async Task<bool> CheckIfExists(FoodsTable food)
        {
            var exist = database.Table<FoodsTable>().Any(x => x.Id == food.Id);
            return exist;
        }

        public async Task<IEnumerable<FoodsTable>> GetConnection()
        {
            return database.Table<FoodsTable>().ToList();
        }

        public async Task<int> InsertFood(FoodsTableAutoCompleteResult food)
        {
            return await InsertFood(new FoodsTable(food));
        }

        public async Task<int> InsertFood(FoodsTable food)
        {
            var num = database.Insert(food);
            database.Commit();
            return num;
        }
        public Task<IEnumerable<FoodsTable>> GetFood()
        {
            return null;
        }

        public Task<int> DeleteFood(object id)
        {
            return null;
        }
    }
}