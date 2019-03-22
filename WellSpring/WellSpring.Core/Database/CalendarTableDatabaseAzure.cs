using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Diagnostics;
using MvvmCross.Platform;

namespace WellSpring.Core.Database
{
    public class CalendarTableDatabaseAzure : ICalendarTableDatabase
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<CalendarTable> azureSyncTable;
        public async Task<bool> CheckIfExists(CalendarTableAutoCompleteResult calen)
        {
            return await CheckIfExists(new CalendarTable(calen));
        }

        public async Task<bool> CheckIfExists(CalendarTable calen)
        {
            await SyncAsync(true);
            var check = await azureSyncTable.Where(x => x.Date == calen.Date).ToListAsync(); //DateTime equal may not work
            return check.Any();
        }

        public async Task<IEnumerable<CalendarTable>> GetConnection()
        {
            await SyncAsync(true);
            return await azureSyncTable.ToListAsync();
        }

        public async Task<int> InsertCalendar(CalendarTableAutoCompleteResult calen)
        {
            return await InsertCalendar(new CalendarTable(calen));
        }

        public async Task<int> InsertCalendar(CalendarTable calen)
        {
            await SyncAsync(true); //opens
            await azureSyncTable.InsertAsync(calen);
            await SyncAsync(); //closes
            return 1;
        }
        public async Task SyncAsync(bool pullData = false)
        {
            try
            {
                if (pullData)
                {
                    await azureSyncTable.PullAsync("allCalendarTables", azureSyncTable.CreateQuery());
                }
                await azureDatabase.SyncContext.PushAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public async Task<IEnumerable<CalendarTable>> GetCalendar()
        {
            await SyncAsync(true);
            var result = await azureSyncTable.ToEnumerableAsync();
            await SyncAsync();
            return result;
        }

        public Task<int> DeleteCalendar(object id)
        {
            return null;
        }

        public CalendarTableDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient("CalendarTable");
            azureSyncTable = azureDatabase.GetSyncTable<CalendarTable>();
        }
    }
}
