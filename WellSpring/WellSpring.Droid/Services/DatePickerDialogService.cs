using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using WellSpring.Core.Interfaces;

//Use code from Xamarin (DatePicker), Author Xamarin Developers, link: https://developer.xamarin.com/guides/android/user_interface/date_picker/, Retrieved 1/11/16

namespace WellSpring.Droid.Services
{
    public class DatePickerDialogService : DialogFragment, DatePickerDialog.IOnDateSetListener
    {
        public static string TAG = "X:" + typeof(DatePickerDialogService).Name.ToUpper();

        Action<DateTime> _dateSelectedHandler = delegate { };

        public static DatePickerDialogService NewInstance(Action<DateTime> onDateSelected)
        {
            DatePickerDialogService frag = new DatePickerDialogService();
            frag._dateSelectedHandler = onDateSelected;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime current = DateTime.Now;
            return new DatePickerDialog(Activity, this, current.Year, current.Month, current.Day);
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            Log.Debug(TAG, selectedDate.ToLongDateString());
            _dateSelectedHandler(selectedDate);
        }
    }
}