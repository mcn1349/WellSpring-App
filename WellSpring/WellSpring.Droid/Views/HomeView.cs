using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using WellSpring.Core.ViewModels;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "Wellspring")]
    public class HomeView : MvxTabActivity
    {
        protected HomeViewModel HomeViewModel
        {
            get { return base.ViewModel as HomeViewModel; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Create your application here
            //Used Slodge's Code, n=25 Tabbed, from https://github.com/MvvmCross/NPlus1DaysOfMvvmCross/tree/master/N-25-Tabbed, retrieved in 21/9/16
            TabHost.TabSpec spec;
            TabHost.SetBackgroundColor(Color.ParseColor("#FFFFFF"));
            TabHost.TabWidget.SetBackgroundColor(Color.ParseColor("#EF678D"));

            spec = TabHost.NewTabSpec("Journey");
            spec.SetIndicator("Journey");
            spec.SetContent(this.CreateIntentFor(HomeViewModel.Journey));
            TabHost.AddTab(spec);


            spec = TabHost.NewTabSpec("Goal");
            spec.SetIndicator("Goal");
            spec.SetContent(this.CreateIntentFor(HomeViewModel.Goal));
            TabHost.AddTab(spec);


            spec = TabHost.NewTabSpec("Statistic");
            spec.SetIndicator("Stats");
            spec.SetContent(this.CreateIntentFor(HomeViewModel.Statistic));
            TabHost.AddTab(spec);


            spec = TabHost.NewTabSpec("Social");
            spec.SetIndicator("Social");
            spec.SetContent(this.CreateIntentFor(HomeViewModel.Community));
            TabHost.AddTab(spec);

        }
    }
}
