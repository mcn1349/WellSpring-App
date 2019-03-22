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
    [Activity(Label = "View for StatisticsDetailViewModel")]
    public class StatisticsDetailView : MvxActivity
    {
        EditText startStr;
        EditText endStr;
        //LinearLayout lay1;
        //LinearLayout lay2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StatisticsDetailView);

            startStr = FindViewById<EditText>(Resource.Id.DateStr1);
            endStr = FindViewById<EditText>(Resource.Id.DateStr2);
            //lay1 = FindViewById<LinearLayout>(Resource.Id.startDate);
            //lay2 = FindViewById<LinearLayout>(Resource.Id.endDate);

            var set = this.CreateBindingSet<StatisticsDetailView, StatisticsDetailViewModel>();

            set.Bind(startStr).For(v => v.Text).To(vm => vm.FromStr);
            set.Bind(endStr).For(v => v.Text).To(vm => vm.ToStr);
            set.Apply();

            startStr.Click += StartDateSelectOnClick;
            endStr.Click += FinishDateSelectOnClick;

        }

        public void StartDateSelectOnClick(object sender, EventArgs r)
        {
            DatePickerDialogService dialog = DatePickerDialogService.NewInstance(delegate (DateTime time) {
                startStr.Text = time.ToString("dd/MM/yyyy");
            });
            dialog.Show(FragmentManager, DatePickerDialogService.TAG);
        }
        public void FinishDateSelectOnClick(object sender, EventArgs r)
        {
            DatePickerDialogService dialog = DatePickerDialogService.NewInstance(delegate (DateTime time) {
                endStr.Text = time.ToString("dd/MM/yyyy");
            });
            dialog.Show(FragmentManager, DatePickerDialogService.TAG);
        }
    }
}