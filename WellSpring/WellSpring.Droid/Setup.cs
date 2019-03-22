using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Dialog.Droid;
using MvvmCross.Platform;
using WellSpring.Core.Interfaces;
using WellSpring.Droid.Database;
using WellSpring.Core.Database;
using WellSpring.Droid.Services;
using WellSpring.Droid.Maps;

namespace WellSpring.Droid
{
    public class Setup : MvxAndroidDialogSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SqliteDroid>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.LazyConstructAndRegisterSingleton<IAzureDatabase, AzureDatabase>();
            Mvx.LazyConstructAndRegisterSingleton<ICalendarTableDatabase, CalendarTableDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<ICommunityPostTableDatabase, CommunityPostTableDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IConsultTableDatabase, ConsultTableDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IExerciseEnteredTableDatabase, ExerciseEnteredTableDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IExerciseTableDatabase, ExerciseTableDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IFoodEnteredTableDatabase, FoodEnteredTableDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IFoodsTableDatabase, FoodsTableDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IMeetupsTableDatabase, MeetupsTableDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IUserTableDatabase, UserTableDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<ILocationsDatabase, LocationDatabaseAzure>();
            Mvx.LazyConstructAndRegisterSingleton<IGeoCoder, GeoCoder>();
            base.InitializeFirstChance();
        }
    }
}