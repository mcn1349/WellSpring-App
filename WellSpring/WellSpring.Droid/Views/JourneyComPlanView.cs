using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "ComPlanView")]
    public class JourneyComPlanView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.JourneyComPlanView);
            // Create your application here
        }
    }
}
