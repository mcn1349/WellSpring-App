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
    public class ExerciseTableDatabaseAzure : IExerciseTableDatabase
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<ExerciseTable> azureSyncTable;
        public async Task<bool> CheckIfExists(ExerciseTableAutoCompleteResult exercise)
        {
            return await CheckIfExists(new ExerciseTable(exercise));
        }

        public async Task<bool> CheckIfExists(ExerciseTable exercise)
        {
            await SyncAsync(true);
            var check = await azureSyncTable.Where(x => x.Id == exercise.Id).ToListAsync(); //DateTime equal may not work
            return check.Any();
        }

        public async Task<IEnumerable<ExerciseTable>> GetConnection()
        {
            await SyncAsync(true);
            return await azureSyncTable.ToListAsync();
        }

        public async Task<int> InsertExercise(ExerciseTableAutoCompleteResult exercise)
        {
            return await InsertExercise(new ExerciseTable(exercise));
        }

        public async Task<int> InsertExercise(ExerciseTable exercise)
        {
            await SyncAsync(true); //opens
            await azureSyncTable.InsertAsync(exercise);
            await SyncAsync(); //closes
            return 1;
        }
        public async Task<IEnumerable<ExerciseTable>> GetExercise()
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
                    await azureSyncTable.PullAsync("allExerciseTables", azureSyncTable.CreateQuery());
                }
                await azureDatabase.SyncContext.PushAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public Task<int> DeleteExercise(object id)
        {
            return null;
        }

        public ExerciseTableDatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient("ExerciseTable");
            azureSyncTable = azureDatabase.GetSyncTable<ExerciseTable>();
        }
    }
}
