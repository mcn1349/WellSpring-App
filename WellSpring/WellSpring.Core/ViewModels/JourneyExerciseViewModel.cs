using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WellSpring.Core.ViewModels
{
    public class JourneyExerciseViewModel
        : MvxViewModel
    {

        public JourneyExerciseViewModel()
        {
            Running = new JourneyExercise_RunningViewModel();
            Workout = new JourneyExercise_WorkoutViewModel();
            Yoga = new JourneyExercise_YogaViewModel();
        }

        private JourneyExercise_RunningViewModel _running;
        public JourneyExercise_RunningViewModel Running
        {
            get { return _running; }
            set { SetProperty(ref _running, value); }
        }
        private JourneyExercise_WorkoutViewModel _workout;
        public JourneyExercise_WorkoutViewModel Workout
        {
            get { return _workout; }
            set { SetProperty(ref _workout, value); }
        }
        private JourneyExercise_YogaViewModel _yoga;
        public JourneyExercise_YogaViewModel Yoga
        {
            get { return _yoga; }
            set { SetProperty(ref _yoga, value); }
        }
        
        private string _exercise = "Exercise";
        public string Exercise
        {
            get { return _exercise; }
            set
            {
                if (value != null && value != _exercise)
                {
                    _exercise = value;
                    RaisePropertyChanged(() => Exercise);
                }
            }
        }
        public static string Name;

        private string _exerciseName;
        public string ExerciseName
        {
            get { return _exerciseName; }
            set
            {
                if (value != null && value != _exerciseName)
                {
                    _exerciseName = value;
                    RaisePropertyChanged(() => ExerciseName);
                    Name = _exerciseName;
                }
            }
        }
    }

}
