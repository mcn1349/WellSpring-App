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
    public class CalendarTableDatabase : ICalendarTableDatabase
    {
        private SQLiteConnection database;

        public CalendarTableDatabase()
        {
            ISqlite sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<CalendarTable>();
        }
        public async Task<bool> CheckIfExists(CalendarTableAutoCompleteResult calen)
        {
            return await CheckIfExists(new CalendarTable(calen));
        }

        public async Task<bool> CheckIfExists(CalendarTable calen)
        {
            var exist = database.Table<CalendarTable>().Any(x => x.Id == calen.Id);
            return exist;
        }

        public Task<int> DeleteCalendar(object id)
        {
            return null;
        }

        public Task<IEnumerable<CalendarTable>> GetCalendar()
        {
            return null;
        }

        public async Task<IEnumerable<CalendarTable>> GetConnection()
        {
            return database.Table<CalendarTable>().ToList();
        }

        public async Task<int> InsertCalendar(CalendarTableAutoCompleteResult calen)
        {
            return await InsertCalendar(new CalendarTable(calen));
        }

        public async Task<int> InsertCalendar(CalendarTable calen)
        {
            var num = database.Insert(calen);
            database.Commit();
            return num;
        }
    }
}
