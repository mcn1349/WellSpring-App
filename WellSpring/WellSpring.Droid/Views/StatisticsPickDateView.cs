using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WellSpring.Droid.Views
{
    [Activity(Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class StatisticsPickDateView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StatisticsPickDateView);
        }
    }
}