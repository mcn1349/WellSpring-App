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
    public class JourneyDatabase : IJourneyDatabase
    {
        private SQLiteConnection database;
        public JourneyDatabase()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<TodoItem>();
        }
        
        //public async Task<IEnumerable<Location>> GetLocations()
        //{
        //    return database.Table<Location>().ToList();
        //}

        //public async Task<int> DeleteLocation(object id)
        //{
        //    return database.Delete<Location>(Convert.ToInt16(id));
        //}

        //public async Task<int> InsertLocation(Location location)
        //{
        //    var num = database.Insert(location);
        //    database.Commit();
        //    return num;
        //}

        //public async Task<bool> CheckIfExists(Location location)
        //{
        //    var exists = database.Table<Location>()
        //        .Any(x => x.LocalizedName == location.LocalizedName
        //        || x.Key == location.Key);
        //    return exists;
        //}

        //public async Task<int> InsertLocation(LocationAutoCompleteResult location)
        //{
        //    return await InsertLocation(new Models.Location(location));
        //}

        //public async Task<bool> CheckIfExists(LocationAutoCompleteResult location)
        //{
        //    return await CheckIfExists(new Location(location));
        //}
        
    }
}
