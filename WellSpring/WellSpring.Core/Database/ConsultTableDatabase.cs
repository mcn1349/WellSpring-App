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
    public class ConsultTableDatabase : IConsultTableDatabase
    {
        private SQLiteConnection database;

        public ConsultTableDatabase(ISqlite sqlite)
        {
            database = sqlite.GetConnection();
            database.CreateTable<ConsultTable>();
        }
        public async Task<bool> CheckIfExists(ConsultTableAutoCompleteResult consult)
        {
            return await CheckIfExists(new ConsultTable(consult));
        }

        public async Task<bool> CheckIfExists(ConsultTable consult)
        {
            var exist = database.Table<ConsultTable>().Any(x => x.Id == consult.Id);
            return exist;
        }

        public async Task<IEnumerable<ConsultTable>> GetConnection()
        {
            return database.Table<ConsultTable>().ToList();
        }

        public async Task<int> InsertConsult(ConsultTableAutoCompleteResult consult)
        {
            return await InsertConsult(new ConsultTable(consult));
        }

        public async Task<int> InsertConsult(ConsultTable consult)
        {
            var num = database.Insert(consult);
            database.Commit();
            return num;
        }
    }
}
