using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "CalendarSelectView")]
    public class JourneyCalendarSelectView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.JourneyCalendarSelectView);
            // Create your application here
        }
    }
}
