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
    public class ExerciseEnteredTableDatabaseAzure : IExerciseEnteredTableDatabase
    {

        private MobileServiceClient azureDatabase;

        private IMobileServiceSyncTable<ExerciseEnteredTable> azureSyncTable;

        public async Task<bool> CheckIfExists(ExerciseEnteredTableAutoCompleteResult exercise)
        {
            return await CheckIfExists(new ExerciseEnteredTable(exercise));
        }

        public async Task<bool> CheckIfExists(ExerciseEnteredTable exercise)
        {
            await SyncAsync(true);
            var check = await azureSyncTable.Where(x => x.ExerciseID == exercise.ExerciseID).ToListAsync();
            return check.Any();
        }

        public async Task<IEnumerable<ExerciseEnteredTable>> GetConnection()
        {
            await SyncAsync(true);
            return await azureSyncTable.ToListAsync();
        }

        public async Task<int> InsertExercise(ExerciseEnteredTableAutoCompleteResult exercise)
        {
            return await InsertExercise(new ExerciseEnteredTable(exercise));
        }

        public async Task<int> InsertExercise(ExerciseEnteredTable exercise)
        {
            await SyncAsync(true); //opens
            await azureSyncTable.InsertAsync(exercise);
            await SyncAsync(); //closes
            return 1;
        }

        public async Task<IEnumerable<ExerciseEnteredTable>> GetExercise()
        {
            await SyncAsync(true);
            var result = await azureSyncTable.ToEnumerableAsync();
            await SyncAsync();
            return result;
        }
        

        public async Task SyncAsync(bool pullData = false)
        {
            try
            {
                if (pullData)
                {
                    await azureSyncTable.PullAsync("allExerciseEnteredTables", azureSyncTable.CreateQuery());
                }
                await azureDatabase.SyncContext.PushAsync();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public ExerciseEnteredTableDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient("ExerciseEnteredTable");
            azureSyncTable = azureDatabase.GetSyncTable<ExerciseEnteredTable>();
        }
        ///public IMobileServiceTable GetTable(string tableName);
    }
}