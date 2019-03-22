using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using WellSpring.Core.ViewModels;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "FoodView")]
    public class JourneyFood_CustomFoodView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.JourneyFood_CustomFoodView);
            // Create your application here
        }
    }
}
