using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WellSpring.Core.ViewModels
{
    public class JourneyFood_CustomFoodViewModel
        : MvxViewModel
    {
        


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


        // Food Info
        private MvxCommand _goFoodInfoCommand;
        public ICommand GoFoodInfoCommand
        {
            get
            {
                _goFoodInfoCommand = _goFoodInfoCommand ?? new MvxCommand(DoGoFoodInfo);
                return _goFoodInfoCommand;
            }
        }

        public void DoGoFoodInfo()
        {
            ShowViewModel<JourneyFoodInfoViewModel>();
        }


    }
}
