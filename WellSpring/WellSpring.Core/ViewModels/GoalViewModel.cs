using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WellSpring.Core.ViewModels
{
    public class GoalViewModel
        : MvxViewModel
    {
        private string search;
        public string Search
        {
            get { return search; }
            set { SetProperty(ref search, value); }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public ICommand GoalSelect { get; set; }
        public ICommand CreateGoalCommand { get; set; }
        public GoalViewModel()
        {
            CreateGoalCommand = new MvxCommand(() =>
            {
                ShowViewModel<CreateGoalViewModel>();
            });
        }
    }
}
