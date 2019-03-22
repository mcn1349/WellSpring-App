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
    public class ConsultTableDatabaseAzure : IConsultTableDatabase
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<ConsultTable> azureSyncTable;
        public async Task<bool> CheckIfExists(ConsultTableAutoCompleteResult consult)
        {
            return await CheckIfExists(new ConsultTable(consult));
        }

        public async Task<bool> CheckIfExists(ConsultTable consult)
        {
            await SyncAsync(true);
            var check = await azureSyncTable.Where(x => x.Question == consult.Question).ToListAsync();
            return check.Any();
        }

        public async Task<IEnumerable<ConsultTable>> GetConnection()
        {
            await SyncAsync(true);
            return await azureSyncTable.ToListAsync();
        }

        public async Task<int> InsertConsult(ConsultTableAutoCompleteResult consult)
        {
            return await InsertConsult(new ConsultTable(consult));
        }

        public async Task<int> InsertConsult(ConsultTable consult)
        {
            await SyncAsync(true); //opens
            await azureSyncTable.InsertAsync(consult);
            await SyncAsync(); //closes
            return 1;
        }
        public async Task SyncAsync(bool pullData = false)
        {
            try
            {
                if (pullData)
                {
                    await azureSyncTable.PullAsync("allConsultTables", azureSyncTable.CreateQuery());
                }
                await azureDatabase.SyncContext.PushAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public ConsultTableDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient("ConsultTable");
            azureSyncTable = azureDatabase.GetSyncTable<ConsultTable>();
        }

    }
}
