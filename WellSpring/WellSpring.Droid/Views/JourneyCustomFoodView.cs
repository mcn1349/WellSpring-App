using Android.App;
using Android.Content;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "CustomFoodView")]
    public class JourneyCustomFoodView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.JourneyCustomFoodView);
            // Create your application here
                        
        }
    }
    
}
