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
    public class MeetupsTableDatabase : IMeetupsTableDatabase
    {
        private SQLiteConnection database;

        public MeetupsTableDatabase()
        {
            ISqlite sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<MeetupsTable>();
        }
        public async Task<bool> CheckIfExists(MeetupsTableAutoCompleteResult meetUp)
        {
            return await CheckIfExists(new MeetupsTable(meetUp));
        }

        public async Task<bool> CheckIfExists(MeetupsTable meetUp)
        {
            var exist = database.Table<MeetupsTable>().Any(x => x.Id == meetUp.Id);
            return exist;
        }

        public async Task<IEnumerable<MeetupsTable>> GetConnection()
        {
            return database.Table<MeetupsTable>().ToList();
        }

        public async Task<int> InsertMeetUp(MeetupsTableAutoCompleteResult meetUp)
        {
            return await InsertMeetUp(new MeetupsTable(meetUp));
        }

        public async Task<int> InsertMeetUp(MeetupsTable meetUp)
        {
            var num = database.Insert(meetUp);
            database.Commit();
            return num;
        }

        public Task<IEnumerable<MeetupsTable>> GetMeetUp()
        {
            return null;
        }
        

        public Task<int> DeleteMeetUp(object id)
        {
            return null;
        }
    }
}
