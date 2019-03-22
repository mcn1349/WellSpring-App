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
    public class FoodEnteredTableDatabaseAzure : IFoodEnteredTableDatabase
    {

        private MobileServiceClient azureDatabase;

        private IMobileServiceSyncTable<FoodEnteredTable> azureSyncTable;

        public async Task<bool> CheckIfExists(FoodEnteredTableAutoCompleteResult food)
        {
            return await CheckIfExists(new FoodEnteredTable(food));
        }

        public async Task<bool> CheckIfExists(FoodEnteredTable food)
        {
            await SyncAsync(true);
            var check = await azureSyncTable.Where(x => x.FoodID == food.FoodID).ToListAsync();
            return check.Any();
        }

        public async Task<IEnumerable<FoodEnteredTable>> GetConnection()
        {
            await SyncAsync(true);
            return await azureSyncTable.ToListAsync();
        }

        public async Task<int> InsertFood(FoodEnteredTableAutoCompleteResult food)
        {
            return await InsertFood(new FoodEnteredTable(food));
        }

        public async Task<int> InsertFood(FoodEnteredTable food)
        {
            await SyncAsync(true); //opens
            await azureSyncTable.InsertAsync(food);
            await SyncAsync(); //closes
            return 1;
        }

        public async Task<IEnumerable<FoodEnteredTable>> GetFood()
        {
            await SyncAsync(true);
            var result = await azureSyncTable.ToEnumerableAsync();
            await SyncAsync();
            return result;
        }

        public async Task<int> DeleteFood(object id)
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
                    await azureSyncTable.PullAsync("allFoodEnteredTables", azureSyncTable.CreateQuery());
                }
                await azureDatabase.SyncContext.PushAsync();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public FoodEnteredTableDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient("FoodEnteredTable");
            azureSyncTable = azureDatabase.GetSyncTable<FoodEnteredTable>();
        }
        ///public IMobileServiceTable GetTable(string tableName);
    }
}