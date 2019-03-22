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
    public class UserTableDatabase : IUserTableDatabase
    {
        private SQLiteConnection database;

        public UserTableDatabase()
        {
            ISqlite sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<UserTable>();
        }
        public async Task<bool> CheckIfExists(UserTableAutoCompleteResult user)
        {
            return await CheckIfExists(new UserTable(user));
        }

        public async Task<bool> CheckIfExists(UserTable user)
        {
            var exist = database.Table<UserTable>().Any(x => x.Id == user.Id);
            return exist;
        }

        public async Task<IEnumerable<UserTable>> GetConnection()
        {
            return database.Table<UserTable>().ToList();
        }

        public async Task<int> InsertUser(UserTableAutoCompleteResult user)
        {
            return await InsertUser(new UserTable(user));
        }

        public async Task<int> InsertUser(UserTable user)
        {
            var num = database.Insert(user);
            database.Commit();
            return num;
        }

        public Task<IEnumerable<UserTable>> GetUser()
        {
            return null;
        }
        

        public Task<int> DeleteMeetUp(object id)
        {
            return null;
        }
    }
}
