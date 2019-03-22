using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Dialog.Droid.Views;
using MvvmCross.Droid.Views;
using System;
using WellSpring.Core.ViewModels;
using WellSpring.Droid.Services;
using WellSpring.Droid.Views;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "MessageView")]
    public class CommunityMessageView : MvxActivity
    {
        EditText DateDisplay;
        Button DateSelectButton;

        EditText TimeDisplay;
        Button TimeSelectButton;

        int Hour;
        int Minute;

        const int TIME_DIALOG_ID = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CommunityMessageView);
            // Create your application here

            DateDisplay = FindViewById<EditText>(Resource.Id.date);
            TimeDisplay = FindViewById<EditText>(Resource.Id.time);

            var set = this.CreateBindingSet<CommunityMessageView, CommunityMessageViewModel>();
            DateSelectButton = FindViewById<Button>(Resource.Id.datepickertest);
            TimeSelectButton = FindViewById<Button>(Resource.Id.timepickertest);
            
            set.Bind(DateDisplay).For(v => v.Text).To(vm => vm.Date);
            set.Bind(TimeDisplay).For(v => v.Text).To(vm => vm.Time);
            set.Apply();

            DateSelectButton.Click += DateSelectOnClick;
            TimeSelectButton.Click += (o, e) => ShowDialog(TIME_DIALOG_ID);

            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;

            UpdateDisplay();
        }
        //Use code from Xamarin (DatePicker), Author Xamarin Developers, link: https://developer.xamarin.com/guides/android/user_interface/date_picker/, Retrieved 1/11/16
        //Use code from Xamarin (TimePicker), Author Xamarin Developers, link: https://developer.xamarin.com/guides/android/user_interface/time_picker/, Retrieved 1/11/16
        public void  DateSelectOnClick(object sender, EventArgs r)
        {
            DatePickerDialogService dialog = DatePickerDialogService.NewInstance(delegate (DateTime time) {
                DateDisplay.Text = time.ToLongDateString();
            });
            dialog.Show(FragmentManager, DatePickerDialogService.TAG);
        }

        private void UpdateDisplay ()
        {
            string time = string.Format("{0}:{1}", Hour, Minute.ToString().PadLeft(2, '0'));
            TimeDisplay.Text = time;
        }

        private void TimePickerCallback (object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            Hour = e.HourOfDay;
            Minute = e.Minute;
            UpdateDisplay();
        }

        protected override Dialog OnCreateDialog(int id)
        {
            if (id == TIME_DIALOG_ID)
            {
                return new TimePickerDialog(this, TimePickerCallback, Hour
                    , Minute, false);
            }
            return null;
        }
    }
}
