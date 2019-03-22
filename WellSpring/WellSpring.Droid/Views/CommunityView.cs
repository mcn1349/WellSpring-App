using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using WellSpring.Core.ViewModels;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "CommunityView")]
    public class CommunityView : MvxActivity //MvxTabActivity
    {
        protected CommunityViewModel CommunityViewModel
        {
            get { return base.ViewModel as CommunityViewModel; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CommunityView);
            // Create your application here

            /*
            TabHost.TabSpec spec;
            TabHost.SetBackgroundColor(Color.ParseColor("#FFFFFF"));
            TabHost.TabWidget.SetBackgroundColor(Color.ParseColor("#EF678D"));

            spec = TabHost.NewTabSpec("New");
            spec.SetIndicator("New");
            spec.SetContent(this.CreateIntentFor(CommunityViewModel.New));
            TabHost.AddTab(spec);


            spec = TabHost.NewTabSpec("Grossing");
            spec.SetIndicator("Grossing");
            spec.SetContent(this.CreateIntentFor(CommunityViewModel.Grossing));
            TabHost.AddTab(spec);


            spec = TabHost.NewTabSpec("Following");
            spec.SetIndicator("Following");
            spec.SetContent(this.CreateIntentFor(CommunityViewModel.Following));
            TabHost.AddTab(spec);
            */
        }
    }
}
