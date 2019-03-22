using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Newtonsoft.Json.Linq;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;
using SQLitePCL;
using System.Collections;

namespace WellSpring.Core.Database
{
    public class MeetupsTableDatabaseAzure : IMeetupsTableDatabase
    {

        private MobileServiceClient azureDatabase;

        private IMobileServiceSyncTable<MeetupsTable> azureSyncTable;

        public async Task<bool> CheckIfExists(MeetupsTableAutoCompleteResult meetUp)
        {
            return await CheckIfExists(new MeetupsTable(meetUp));
        }

        public async Task<bool> CheckIfExists(MeetupsTable meetUp)
        {
            await SyncAsync(true);
            var check = await azureSyncTable.Where(x => x.Id == meetUp.Id).ToListAsync();
            return check.Any();
        }

        public async Task<IEnumerable<MeetupsTable>> GetConnection()
        {
            await SyncAsync(true);
            return await azureSyncTable.ToListAsync();
        }

        public async Task<int> InsertMeetUp(MeetupsTableAutoCompleteResult meetUp)
        {
            return await InsertMeetUp(new MeetupsTable(meetUp));
        }

        public async Task<int> InsertMeetUp(MeetupsTable meetUp)
        {
            await SyncAsync(true); //opens
            await azureSyncTable.InsertAsync(meetUp);
            await SyncAsync(); //closes
            return 1;
        }

        public async Task<IEnumerable<MeetupsTable>> GetMeetUp()
        {
            await SyncAsync(true);
            var meet = await azureSyncTable.ToEnumerableAsync();
            await SyncAsync();
            return meet;
        }

        public async Task<int> DeleteMeetUp(object id)
        {
            await SyncAsync(true);
            var meetUp = await azureSyncTable.Where(x => x.Id == (string)id).ToListAsync();
            if (meetUp.Any())
            {
                await azureSyncTable.DeleteAsync(meetUp.FirstOrDefault());
                await SyncAsync();
                return 1;
            }
            else
            {
                return 0;

            }
        }

        public async Task SyncAsync(bool pullData = false)
        {
            try
            {
                if (pullData)
                {
                    await azureSyncTable.PullAsync("allMeetupsTables", azureSyncTable.CreateQuery());
                }
                await azureDatabase.SyncContext.PushAsync();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public MeetupsTableDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient("MeetupsTable");
            azureSyncTable = azureDatabase.GetSyncTable<MeetupsTable>();
        }
        ///public IMobileServiceTable GetTable(string tableName);
    }
}
