using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class JourneyOrganiserViewModel
        : MvxViewModel
    {

        UserTableAutoCompleteResult user = new UserTableAutoCompleteResult();
        FoodEnteredTableAutoCompleteResult foods = new FoodEnteredTableAutoCompleteResult();
        ExerciseEnteredTableAutoCompleteResult exers = new ExerciseEnteredTableAutoCompleteResult();

        private ObservableCollection<FoodsTable> meals = new ObservableCollection<FoodsTable>();
        public ObservableCollection<FoodsTable> Meals
        {
            get { return meals; }
            set { SetProperty(ref meals, value); }
        }

        private ObservableCollection<ExerciseTable> exercises = new ObservableCollection<ExerciseTable>();
        public ObservableCollection<ExerciseTable> Exercises
        {
            get { return exercises; }
            set { SetProperty(ref exercises, value); }
        }
        enum MonthsName { January = 1, February = 2, March = 3, April = 4, May = 5, June = 6, July = 7, August = 8, September = 9, October = 10, November = 11, December = 12 }

        //private static IRepository Repository;

        public static DateTime _getdate = DateTime.Now;// = Repository.GetDate();

        private static DateTime selectedDate = _getdate; //DateTime.Now; //new DateTime(2016, 9, 27);

        private static int Day = selectedDate.Day;//dateParse(String.Format("{0:dd}"));
        private static int Month = selectedDate.Month;//dateParse(String.Format("{0:MM}")) ;
        private static int Year = selectedDate.Year;//dateParse(String.Format("{0:yyyy}")); 


        private static int goalValue = 1755;
        private static int eatenValue = 0;
        private static int burnedValue = 0;
        private static int remainingValue = remainder();

        private static int progressCalories = 0;

        IUserTableDatabase enteredUser;
        IFoodEnteredTableDatabase enteredFood;
        IFoodsTableDatabase foodDatabase;
        IExerciseEnteredTableDatabase enteredExer;
        IExerciseTableDatabase exerDatabase;


        public async void Init()
        {
            await ShowList();
        }

        public async void OnResume()
        {
            await ShowList();
        }

        private async Task ShowList()
        {
            string userid = await getuserid();
            string foodid = "";
            Meals.Clear();
            //Meals = new ObservableCollection<FoodsTable>();
            enteredFood = new FoodEnteredTableDatabaseAzure();
            foodDatabase = new FoodsTableDatabaseAzure();

            var mealdetails = await enteredFood.GetFood();
            foreach (var detail in mealdetails)
            {
                if (detail.UserID == userid)
                {
                    foodid = detail.FoodID;
                    var datas = await foodDatabase.GetFood();
                    foreach (var data in datas)
                    {
                        if (data.Id == foodid)
                        {
                            Meals.Add(data);
                            eatenValue += data.Calories;
                            Eaten = "" + eatenValue;
                            remainingValue = remainder();
                            Remaining = "" + remainingValue;
                        }
                    }
                }
            }

            string exerciseid = "";
            Exercises.Clear();
            //Exercises = new ObservableCollection<ExerciseTable>(); 
            enteredExer = new ExerciseEnteredTableDatabaseAzure();
            exerDatabase = new ExerciseTableDatabaseAzure();

            var exerdetails = await enteredExer.GetExercise();
            foreach (var detail in exerdetails)
            {
                if (detail.UserID == userid)
                {
                    exerciseid = detail.ExerciseID;
                    var datas = await exerDatabase.GetExercise();
                    foreach (var data in datas)
                    {
                        if (data.Id == exerciseid)
                        {
                            Exercises.Add(data);
                            burnedValue += data.Calories;
                            Burned = "" + burnedValue;
                            remainingValue = remainder();
                            Remaining = "" + remainingValue;
                        }
                    }
                }
            }
        }
        

        public async Task<string> getuserid()
        {
            string _userid = "";
            enteredUser = new UserTableDatabaseAzure();
            var details = await enteredUser.GetUser();
            foreach (var detail in details)
            {
                if (detail.Name == "Kazuko")
                {
                    _userid = detail.Id;
                }

            }
            return _userid;
        }






        private string _date = dateSelect();
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



        public static string dateSelect()
        {
            string _selectDate = "";
            Progression();
            string _days = dateDay();
            string _months = dateMonth();



            _selectDate = _days + " " + _months + " " + Year;
            return _selectDate;
        }


        public static void Progression()
        {
            int MaxMonths = 12;
            int CurrentMonth = Month;
            int MaxDays = DateTime.DaysInMonth(Year, CurrentMonth);

            int PreMonths = CurrentMonth - 1;
            int PreMaxDays;
            if (PreMonths <= 0)
            {
                PreMonths = MaxMonths;
            }
            PreMaxDays = DateTime.DaysInMonth(Year, PreMonths);

            ////-----------------------
            if (Day > MaxDays)
            {
                Month += 1;
                Day = 1;
            }
            else if (Day <= 0)
            {
                Month -= 1;
                Day = PreMaxDays;
            }
            ////-----------------------
            if (Month > MaxMonths)
            {
                Month = 1;
                Year += 1;
            }
            else if (Month <= 0)
            {
                Month = MaxMonths;
                Year -= 1;
            }
            ////-----------------------

        }


        public static string dateDay()
        {
            string _day = "";

            int _Days = Day;

            if (_Days == 1 || _Days == 21 || _Days == 31) { _day = _Days + "st"; }
            else if (_Days == 2 || _Days == 22) { _day = _Days + "nd"; }
            else if (_Days == 3 || _Days == 23) { _day = _Days + "rd"; }
            else { _day = _Days + "th"; }

            return _day;
        }

        public static string dateMonth()
        {
            int _Month = Month;
            MonthsName _months = (MonthsName)(Month);
            string _month = "" + _months;
            return _month;
        }




        private MvxCommand _previousDateCommand;
        public ICommand PreviousDateCommand
        {
            get
            {
                _previousDateCommand = _previousDateCommand ?? new MvxCommand(DoPreviousDate);
                return _previousDateCommand;
            }
        }

        public void DoPreviousDate()
        {
            Day -= 1;
            //selectedDate.AddDays(-1);
            Date = dateSelect();
            progressCalories -= 5;
            CalorieProgress = progressCalories;
            //colorSelection(progressCalories);
        }


        private MvxCommand _nextDateCommand;
        public ICommand NextDateCommand
        {
            get
            {
                _nextDateCommand = _nextDateCommand ?? new MvxCommand(DoNextDate);
                return _nextDateCommand;
            }
        }

        public void DoNextDate()
        {
            Day += 1;
            //selectedDate.AddDays(1);
            Date = dateSelect();
            progressCalories += 5;
            CalorieProgress = progressCalories;
            //colorSelection(progressCalories);
            
        }

        //-------------------------------------------------------------------------------------

        private string _goal = "" + goalValue;
        public string Goal
        {
            get { return _goal; }
            set
            {
                if (value != null && value != _goal)
                {
                    _goal = value;
                    RaisePropertyChanged(() => Goal);
                }
            }
        }

        private string _eaten = "" + eatenValue;
        public string Eaten
        {
            get { return _eaten; }
            set
            {
                if (value != null && value != _eaten)
                {
                    _eaten = value;
                    RaisePropertyChanged(() => Eaten);
                }
            }
        }

        private string _burned = "" + burnedValue;
        public string Burned
        {
            get { return _burned; }
            set
            {
                if (value != null && value != _burned)
                {
                    _burned = value;
                    RaisePropertyChanged(() => Burned);
                }
            }
        }

        private string _remaining = "" + remainingValue;
        public string Remaining
        {
            get { return _remaining; }
            set
            {
                if (value != null && value != _remaining)
                {
                    _remaining = value;
                    RaisePropertyChanged(() => Remaining);
                }
            }
        }

        private static int remainder()
        {
            int gValue = goalValue;
            int eValue = eatenValue;
            int bValue = burnedValue;
            int rValue = 0;

            rValue = ((gValue - eValue) + bValue);
            return rValue;
        }

        //-------------------------------------------------------------------------------------

        private double _calorieProgress = progressCalories;
        public double CalorieProgress
        {
            get { return _calorieProgress; }
            set
            {
                SetProperty(ref _calorieProgress, progressCalories);
            }
        }

        //-------------------------------------------------------------------------------------


        // Food
        private MvxCommand _goFoodCommand;
        public ICommand GoFoodCommand
        {
            get
            {
                _goFoodCommand = _goFoodCommand ?? new MvxCommand(DoGoFood);
                return _goFoodCommand;
            }
        }

        public void DoGoFood()
        {
            ShowViewModel<JourneyFoodViewModel>();
        }


        // Exercise
        private MvxCommand _goExerciseCommand;
        public ICommand GoExerciseCommand
        {
            get
            {
                _goExerciseCommand = _goExerciseCommand ?? new MvxCommand(DoGoExercise);
                return _goExerciseCommand;
            }
        }

        public void DoGoExercise()
        {
            ShowViewModel<JourneyExerciseViewModel>();
        }



    }
}
