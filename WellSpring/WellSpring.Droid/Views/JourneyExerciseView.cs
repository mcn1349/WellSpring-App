using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using WellSpring.Core.ViewModels;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "ExerciseView")]
    public class JourneyExerciseView : MvxTabActivity
    {
        protected JourneyExerciseViewModel JourneyExerciseViewModel
        {
            get { return base.ViewModel as JourneyExerciseViewModel; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.JourneyExerciseView);
            // Create your application here

            TabHost.TabSpec spec;
            TabHost.SetBackgroundColor(Color.ParseColor("#FFFFFF"));
            TabHost.TabWidget.SetBackgroundColor(Color.ParseColor("#EF678D"));

            spec = TabHost.NewTabSpec("Running");
            spec.SetIndicator("Running");
            spec.SetContent(this.CreateIntentFor(JourneyExerciseViewModel.Running));
            TabHost.AddTab(spec);


            spec = TabHost.NewTabSpec("Workout");
            spec.SetIndicator("Workout");
            spec.SetContent(this.CreateIntentFor(JourneyExerciseViewModel.Workout));
            TabHost.AddTab(spec);


            spec = TabHost.NewTabSpec("Yoga");
            spec.SetIndicator("Yoga");
            spec.SetContent(this.CreateIntentFor(JourneyExerciseViewModel.Yoga));
            TabHost.AddTab(spec);

        }
    }
}
