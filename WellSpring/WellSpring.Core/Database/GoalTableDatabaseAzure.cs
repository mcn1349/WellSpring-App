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
    public class GoalTableDatabaseAzure : IGoalTableDatabase
    {

        private MobileServiceClient azureDatabase;

        private IMobileServiceSyncTable<GoalTable> azureSyncTable;

        public async Task<bool> CheckIfExists(GoalTableAutoCompleteResult goal)
        {
            return await CheckIfExists(new GoalTable(goal));
        }

        public async Task<bool> CheckIfExists(GoalTable goal)
        {
            await SyncAsync(true);
            var check = await azureSyncTable.Where(x => x.Id == goal.Id).ToListAsync();
            return check.Any();
        }

        public async Task<IEnumerable<GoalTable>> GetConnection()
        {
            await SyncAsync(true);
            return await azureSyncTable.ToListAsync();
        }

        public async Task<int> InsertGoal(GoalTableAutoCompleteResult goal)
        {
            return await InsertGoal(new GoalTable(goal));
        }

        public async Task<int> InsertGoal(GoalTable goal)
        {
            await SyncAsync(true); //opens
            await azureSyncTable.InsertAsync(goal);
            await SyncAsync(); //closes
            return 1;
        }

        public async Task<IEnumerable<GoalTable>> GetFood()
        {
            await SyncAsync(true);
            var result = await azureSyncTable.ToEnumerableAsync();
            await SyncAsync();
            return result;
        }

        public async Task<int> DeleteGoal(object id)
        {
            await SyncAsync(true);
            var food = await azureSyncTable.Where(x => x.Id == (string)id).ToListAsync();
            if (food.Any())
            {
                await azureSyncTable.DeleteAsync(food.FirstOrDefault());
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
                    await azureSyncTable.PullAsync("allGoalTables", azureSyncTable.CreateQuery());
                }
                await azureDatabase.SyncContext.PushAsync();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public GoalTableDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient("GoalTable");
            azureSyncTable = azureDatabase.GetSyncTable<GoalTable>();
        }
        ///public IMobileServiceTable GetTable(string tableName);
    }
}