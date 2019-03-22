using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class JourneyFoodViewModel
        : MvxViewModel
    {
        public JourneyFoodViewModel()
        {
            Food = new JourneyFood_FoodViewModel();
            Custom_Food = new JourneyFood_CustomFoodViewModel();
        }

        private JourneyFood_FoodViewModel _food;
        public JourneyFood_FoodViewModel Food
        {
            get { return _food; }
            set { SetProperty(ref _food, value); }
        }
        private JourneyFood_CustomFoodViewModel _custom_food;
        public JourneyFood_CustomFoodViewModel Custom_Food
        {
            get { return _custom_food; }
            set { SetProperty(ref _custom_food, value); }
        }




        /*
         * Links
         */


        // Custom Food
        private MvxCommand _goCustomFoodCommand;
        public ICommand GoCustomFoodCommand
        {
            get
            {
                _goCustomFoodCommand = _goCustomFoodCommand ?? new MvxCommand(DoGoCustomFood);
                return _goCustomFoodCommand;
            }
        }

        public void DoGoCustomFood()
        {
            ShowViewModel<JourneyCustomFoodViewModel>();
        }

        //public void DoGoFoodInfo()
        //{
        //    ShowViewModel<JourneyFoodInfoViewModel>();
        //}
    }
}
