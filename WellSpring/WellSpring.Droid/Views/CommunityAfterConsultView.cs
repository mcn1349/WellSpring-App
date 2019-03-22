using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "AfterConsultView")]
    public class CommunityAfterConsultView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CommunityAfterConsultView);
            // Create your application here
        }
    }
}
