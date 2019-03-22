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
    public class UserTableDatabaseAzure : IUserTableDatabase
    {

        private MobileServiceClient azureDatabase;

        private IMobileServiceSyncTable<UserTable> azureSyncTable;

        public async Task<bool> CheckIfExists(UserTableAutoCompleteResult user)
        {
            return await CheckIfExists(new UserTable(user));
        }

        public async Task<bool> CheckIfExists(UserTable user)
        {
            await SyncAsync(true);
            var check = await azureSyncTable.Where(x => x.Name == user.Name).ToListAsync();
            return check.Any();
        }

        public async Task<IEnumerable<UserTable>> GetConnection()
        {
            await SyncAsync(true);
            return await azureSyncTable.ToListAsync();
        }

        public async Task<int> InsertUser(UserTableAutoCompleteResult user)
        {
            return await InsertUser(new UserTable(user));
        }

        public async Task<int> InsertUser(UserTable user)
        {
            await SyncAsync(true); //opens
            await azureSyncTable.InsertAsync(user);
            await SyncAsync(); //closes
            return 1;
        }

        public async Task<IEnumerable<UserTable>> GetUser()
        {
            await SyncAsync(true);
            var meet = await azureSyncTable.ToEnumerableAsync();
            await SyncAsync();
            return meet;
        }

        public async Task SyncAsync(bool pullData = false)
        {
            try
            {
                if (pullData)
                {
                    await azureSyncTable.PullAsync("allUserTables", azureSyncTable.CreateQuery());
                }
                await azureDatabase.SyncContext.PushAsync();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public UserTableDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient("UserTable");
            azureSyncTable = azureDatabase.GetSyncTable<UserTable>();
        }
        ///public IMobileServiceTable GetTable(string tableName);
    }
}
