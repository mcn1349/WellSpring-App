using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using WellSpring.Core.ViewModels;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "FoodView")]
    public class JourneyFoodView : MvxTabActivity
    {
        protected JourneyFoodViewModel JourneyFoodViewModel
        {
            get { return base.ViewModel as JourneyFoodViewModel; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.JourneyFoodView);
            // Create your application here

            TabHost.TabSpec spec;
            TabHost.SetBackgroundColor(Color.ParseColor("#FFFFFF"));
            TabHost.TabWidget.SetBackgroundColor(Color.ParseColor("#EF678D"));

            spec = TabHost.NewTabSpec("Food");
            spec.SetIndicator("Food");
            spec.SetContent(this.CreateIntentFor(JourneyFoodViewModel.Food));
            TabHost.AddTab(spec);


            spec = TabHost.NewTabSpec("Custom Food");
            spec.SetIndicator("Custom Food");
            spec.SetContent(this.CreateIntentFor(JourneyFoodViewModel.Custom_Food));
            TabHost.AddTab(spec);

        }
    }
}
