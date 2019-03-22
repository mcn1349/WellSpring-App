using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "FindMeetupView")]
    public class CommunityFindMeetupView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CommunityFindMeetupView);
            // Create your application here
        }
    }
}
