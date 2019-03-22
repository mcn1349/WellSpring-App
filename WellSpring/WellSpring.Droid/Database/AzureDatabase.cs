using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using WellSpring.Core.Interfaces;
using System.IO;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using WellSpring.Core.Model;

namespace WellSpring.Droid.Database
{
    public class AzureDatabase : IAzureDatabase
    {

        MobileServiceClient azureDatabase;
        public MobileServiceClient GetMobileServiceClient(string TableName)
        {
            CurrentPlatform.Init();

            azureDatabase = new MobileServiceClient("http://wellspringiab.azurewebsites.net/");
            InitializeLocal(TableName);
            return azureDatabase;
        }

        public MobileServiceClient GetMobileServiceClient()
        {
            CurrentPlatform.Init();

            azureDatabase = new MobileServiceClient("http://qutmadsem22016wednesday3.azurewebsites.net/");
            InitializeLocal();
            return azureDatabase;
        }
        private void InitializeLocal(string table)
        {
            var sqliteFilename = "WellSpringSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            var store = new MobileServiceSQLiteStore(path);

            if (table == "CalendarTable")
            {
                store.DefineTable<CalendarTable>();
            }
            else if (table == "CommentTable")
            {

            }
            else if (table == "CommunityPostTable")
            {
                store.DefineTable<CommunityPostTable>();
            }
            else if (table == "ConsultTable")
            {
                store.DefineTable<ConsultTable>();
            }
            else if (table == "CustomFoodsTable")
            {

            }
            else if (table == "ExerciseEnteredTable")
            {
                store.DefineTable<ExerciseEnteredTable>();
            }
            else if (table == "ExerciseTable")
            {
                store.DefineTable<ExerciseTable>();
            }
            else if (table == "FoodEnteredTable")
            {
                store.DefineTable<FoodEnteredTable>();
            }
            else if (table == "FoodsTable")
            {
                store.DefineTable<FoodsTable>();
            }
            else if (table == "GoalTable")
            {
                store.DefineTable<GoalTable>();
            }
            else if (table == "GroupMeetUpMemberTable")
            {

            }
            else if (table == "JourneyTable")
            {

            }
            else if (table == "MeetUpMemberTable")
            {

            }
            else if (table == "MeetupsTable")
            {
                store.DefineTable<MeetupsTable>();
            }
            else if (table == "NurseTable")
            {

            }
            else if (table == "UserTable")
            {
                store.DefineTable<UserTable>();
            }
            else
            {
                store.DefineTable<TodoItem>();
            }

            azureDatabase.SyncContext.InitializeAsync(store);
        }
        private void InitializeLocal()
        {
            var sqliteFilename = "LocationSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Location>();
            azureDatabase.SyncContext.InitializeAsync(store);
        }
    }
}