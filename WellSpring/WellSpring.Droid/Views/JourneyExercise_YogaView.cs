using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using WellSpring.Core.ViewModels;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "ExerciseYogaView")]
    public class JourneyExercise_YogaView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.JourneyExercise_YogaView);
            // Create your application here
        }
    }
}
