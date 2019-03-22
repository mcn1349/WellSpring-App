using Android.App;
using Android.OS;
using Android.Widget;
using CrossUI.Droid.Dialog.Elements;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Dialog.Droid.Views;
using MvvmCross.Droid.Views;
using System;
using WellSpring.Core.ViewModels;
using WellSpring.Droid.Services;

namespace WellSpring.Droid.Views
{
    [Activity(Label = "Wellspring")]
    public class CreateGoalView : MvxActivity
    {
        private static string datetimeformat = "dd/MM/yyyy";
        

        const int TIME_DIALOG_FINISH_ID = 9;

        EditText startDate;
        EditText endDate;
        Button startButt;
        Button endButt;

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateGoalView);

            startDate = FindViewById<EditText>(Resource.Id.startdate);
            endDate = FindViewById<EditText>(Resource.Id.finishdate);
            startButt = FindViewById<Button>(Resource.Id.startDate);
            endButt = FindViewById<Button>(Resource.Id.finishDate);

            var set = this.CreateBindingSet<CreateGoalView, CreateGoalViewModel>();
            set.Bind(startDate).For(v => v.Text).To(vm => vm.StartStr);
            set.Bind(endDate).For(v => v.Text).To(vm => vm.FinishStr);
            set.Apply();

            startDate.Click += StartDateSelectOnClick;
            endDate.Click += FinishDateSelectOnClick;
            startButt.Click += StartDateSelectOnClick;
            endButt.Click += FinishDateSelectOnClick;

        }

        public void StartDateSelectOnClick(object sender, EventArgs r)
        {
            DatePickerDialogService dialog = DatePickerDialogService.NewInstance(delegate (DateTime time) {
                startDate.Text = time.ToString(datetimeformat);
            });
            dialog.Show(FragmentManager, DatePickerDialogService.TAG);
        }
        public void FinishDateSelectOnClick(object sender, EventArgs r)
        {
            DatePickerDialogService dialog = DatePickerDialogService.NewInstance(delegate (DateTime time) {
                endDate.Text = time.ToString(datetimeformat);
            });
            dialog.Show(FragmentManager, DatePickerDialogService.TAG);
        }


    }
}
