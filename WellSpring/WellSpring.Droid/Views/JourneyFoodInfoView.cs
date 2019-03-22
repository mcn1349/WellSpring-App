using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "FoodInfoView")]
    public class JourneyFoodInfoView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.JourneyFoodInfoView);
            // Create your application here
        }
    }
}
