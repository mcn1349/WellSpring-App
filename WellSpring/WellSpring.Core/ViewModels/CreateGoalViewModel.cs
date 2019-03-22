using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class CreateGoalViewModel : MvxViewModel
    {
        private GoalDetails goal = new GoalDetails();
        public ICommand CreateGoalCommand { get; private set; }

        public CreateGoalViewModel()
        {
            CreateGoalCommand = new MvxCommand<GoalDetails>(goal =>
            {
                Close(this);
            });
        }

        private bool check()
        {
            if (Name == null || Name == string.Empty || Details == null || Details == string.Empty)
            {
                return false;
            }
            //string[] date_time = { StartDate, StartTime, FinishDate, FinishTime };
            string[] format = { "dd/MM/yyyy", "HH:mm", "dd/MM/yyyy", "HH:mm" };
            /*bool checker;
            DateTime valid;
            for (int i = 0; i < date_time.Length; i += 1)
            {
                checker = DateTime.TryParseExact(date_time[i], format[i], System.Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None, out valid);
                if (!checker)
                {
                    return false;
                }
            }
            */
            return true;
        }

        private void add_goalDetails()
        {
            goal.title = Name;
            goal.details = Details;
            /*
            goal.StartTime = StartTime;
            goal.StartDate = StartDate;
            goal.FinishTime = FinishTime;
            goal.FinishDate = FinishDate;*/
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _detail;
        public string Details
        {
            get { return _detail; }
            set { SetProperty(ref _detail, value); }
        }



        
        private DateTime _startTime;
        public DateTime StartTime
        {
            get { return _startTime; }
            set { SetProperty(ref _startTime, value); }
        }

        private String _startStr;
        public String StartStr
        {
            get { return _startStr; }
            set { SetProperty(ref _startStr, value);
                _startDate=Convert.ToDateTime(_startStr);
            }
        }

        private String _finishStr;
        public String FinishStr
        {
            get { return _finishStr; }
            set { SetProperty(ref _finishStr, value);
                _finishDate = Convert.ToDateTime(_finishStr);
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }
        private DateTime _finishTime = DateTime.Today;
        public DateTime FinishTime
        {
            get { return _finishTime; }
            set { SetProperty(ref _finishTime, value); }
        }
        private DateTime _finishDate;

        public DateTime FinishDate
        {
            get { return _finishDate; }
            set { SetProperty(ref _finishDate, value); }
        }
        
        
    }
}
