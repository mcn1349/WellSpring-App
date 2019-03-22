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
    public class CommunityPostTableDatabaseAzure : ICommunityPostTableDatabase
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<CommunityPostTable> azureSyncTable;
        public async Task<bool> CheckIfExists(CommunityPostTableAutoCompleteResult post)
        {
            return await CheckIfExists(new CommunityPostTable(post));
        }

        public async Task<bool> CheckIfExists(CommunityPostTable post)
        {
            await SyncAsync(true);
            var check = await azureSyncTable.Where(x => x.HostID == post.HostID).ToListAsync();
            return check.Any();
        }

        public async Task<IEnumerable<CommunityPostTable>> GetConnection()
        {
            await SyncAsync(true);
            return await azureSyncTable.ToListAsync();
        }

        public async Task<int> InsertCommunityPost(CommunityPostTableAutoCompleteResult post)
        {
            return await InsertCommunityPost(new CommunityPostTable(post));
        }

        public async Task<int> InsertCommunityPost(CommunityPostTable post)
        {
            await SyncAsync(true); //opens
            await azureSyncTable.InsertAsync(post);
            await SyncAsync(); //closes
            return 1;
        }
        public async Task SyncAsync(bool pullData = false)
        {
            try
            {
                if (pullData)
                {
                    await azureSyncTable.PullAsync("allCommunityPostTables", azureSyncTable.CreateQuery());
                }
                await azureDatabase.SyncContext.PushAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public CommunityPostTableDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient("CommunityPostTable");
            azureSyncTable = azureDatabase.GetSyncTable<CommunityPostTable>();
        }

        public async Task<IEnumerable<CommunityPostTable>> GetCp()
        {
            await SyncAsync(true);
            var result = await azureSyncTable.ToEnumerableAsync();
            await SyncAsync();
            return result;
        }

    }
}
