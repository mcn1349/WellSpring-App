using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;

namespace WellSpring.Core.ViewModels
{
    public class JourneyCalendarSelectViewModel
        : MvxViewModel
    {
        enum MonthsName { January = 1, February = 2, March = 3, April = 4, May = 5, June = 6, July = 7, August = 8, September = 9, October = 10, November = 11, December = 12 }

        private IRepository Repository;

        //private TodoItemDateAutoCompleteResult ItemDate = new TodoItemDateAutoCompleteResult();

        private static DateTime _thisDate = DateTime.Now;
        public DateTime ThisDate
        {
            get { return _thisDate; }
            set
            {
                if (value != null && value != _thisDate)
                {
                    _thisDate = value;
                    RaisePropertyChanged(() => ThisDate);
                }
            }
        }
        
        

        private static int Day = _thisDate.Day;
        private static int Month = _thisDate.Month;
        private static int Year = _thisDate.Year;

        public static string dateMonth(int _month)
        {
            int ThisMonth = _month;
            MonthsName _thisMonths = (MonthsName)(ThisMonth);
            string _Month = "" + _thisMonths;
            return _Month;
        }

        private static string _Months = dateMonth(Month);

        private string _date = (Day + " " + _Months + " " + Year);//String.Format("{0: dd/MM/yyyy}", now);
        public string Date
        {
            get { return _date; }
            set
            {
                if (value != null && value != _date)
                {
                    
                    _date = value;
                    RaisePropertyChanged(() => Date);
                }
            }
        }
        

        private MvxCommand _goOrganiserCommand;
        public ICommand GoOrganiserCommand
        {
            get
            {
                _goOrganiserCommand = _goOrganiserCommand ?? new MvxCommand(GoToOrganiser);
                return _goOrganiserCommand;
            }
        }

        public void GoToOrganiser()
        {
            //Repository = new Repository();
            //ItemDate.ChosenDate = ThisDate;
            //ItemDate.ID = 5;
            //Repository.SetDate(ItemDate);
            ShowViewModel<JourneyOrganiserViewModel>();
        }
    }
}
