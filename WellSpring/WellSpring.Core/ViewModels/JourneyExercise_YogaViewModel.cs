using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class JourneyExercise_YogaViewModel
        : MvxViewModel
    {
        private string _sets = "10";
        public string Sets
        {
            get { return _sets; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _sets, value);
                }
            }
        }

        private string _duration = "5";
        public string Duration
        {
            get { return _duration; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _duration, value);
                }
            }
        }

        private string _burnedCalories = "300";
        public string BurnedCalories
        {
            get { return _burnedCalories; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _burnedCalories, value);
                }
            }
        }


        private MvxCommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                _addCommand = _addCommand ?? new MvxCommand(Adding);
                return _addCommand;
            }
        }


        public UserTableAutoCompleteResult user = new UserTableAutoCompleteResult();
        public ExerciseEnteredTableAutoCompleteResult entered = new ExerciseEnteredTableAutoCompleteResult();

        public IUserTableDatabase entereduUser;
        public IExerciseEnteredTableDatabase enteredExercise;


        public ExerciseTableAutoCompleteResult exer = new ExerciseTableAutoCompleteResult();
        public IExerciseTableDatabase exerdatabase;


        public async void Adding()
        {
            exer.Name = JourneyExerciseViewModel.Name;
            exer.ExerciseType = "Yoga";

            bool NameCorrect = (exer.Name != null && exer.Name != "");


            bool SetsCorrect = true;
            int SetsVal = 0;
            SetsCorrect = int.TryParse(Sets, out SetsVal);
            exer.Sets = SetsVal;

            bool DurationCorrect = true;
            int DurationVal = 0;
            DurationCorrect = int.TryParse(Duration, out DurationVal);
            exer.Duration = DurationVal;

            bool BurnedCorrect = true;
            int BurnedVal = 0;
            BurnedCorrect = int.TryParse(BurnedCalories, out BurnedVal);
            exer.Calories = BurnedVal;

            
            bool correctValues = (NameCorrect && SetsCorrect && DurationCorrect && BurnedCorrect);
            if (correctValues)
            {
                exerdatabase = new ExerciseTableDatabaseAzure();
                await exerdatabase.InsertExercise(exer);
                var details = await exerdatabase.GetConnection();
                foreach (var detail in details)
                {
                    if (detail.Name == exer.Name && 
                        detail.ExerciseType == exer.ExerciseType &&  
                        detail.Sets == exer.Sets && 
                        detail.Duration == exer.Duration && 
                        detail.Calories == exer.Calories)
                    {
                        exer.Id = detail.Id; 
                    }
                }

                string _exerciseid = exer.Id;
                string _userid = "";

                entereduUser = new UserTableDatabaseAzure();
                var users = await entereduUser.GetUser();
                foreach (var user in users)
                {
                    if (user.Name == "Kazuko")
                    {
                        _userid = user.Id;
                    }

                }

                entered.UserID = _userid;
                entered.ExerciseID = _exerciseid;
                entered.Date = DateTime.Now;

                enteredExercise = new ExerciseEnteredTableDatabaseAzure();
                bool _checked = await enteredExercise.CheckIfExists(entered);
                if (!_checked)
                {
                    await enteredExercise.InsertExercise(entered);
                    Close(this);
                }
            }
        }
    }

}
