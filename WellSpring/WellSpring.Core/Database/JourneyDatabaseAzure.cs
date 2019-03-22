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

namespace WellSpring.Core.Database
{
    public class JourneyDatabaseAzure : IJourneyDatabase
    {
        private TodoItem testItem = new TodoItem();
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<TodoItem> azureSyncTable;
        public JourneyDatabaseAzure()
        {
            azureDatabase = new MobileServiceClient("https://wellspringdb.azurewebsites.net");
            var store = new MobileServiceSQLiteStore("WellspringDB.db");
            store.DefineTable<TodoItem>();
            azureDatabase.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
            azureSyncTable = azureDatabase.GetSyncTable<TodoItem>();
        }
        public async void Something()
        {
            await SyncAsync(true);
            await azureSyncTable.InsertAsync(testItem);
            //var x = await azureSyncTable.ToListAsync();
            await SyncAsync();
        }
        private async Task SyncAsync(bool pullData = false)
        {
            try
            {
                await azureDatabase.SyncContext.PushAsync();

                if (pullData)
                {
                    await azureSyncTable.PullAsync("allTodoItems", azureSyncTable.CreateQuery());
                    // query ID is used for incremental sync
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }
        
    }
}
