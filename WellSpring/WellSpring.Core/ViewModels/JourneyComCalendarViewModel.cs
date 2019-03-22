using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WellSpring.Core.ViewModels
{
    public class JourneyComCalendarViewModel
        : MvxViewModel
    {
        // Community Plan
        private MvxCommand _goPlanCommand;
        public ICommand GoPlanCommand
        {
            get
            {
                _goPlanCommand = _goPlanCommand ?? new MvxCommand(DoGoPlan);
                return _goPlanCommand;
            }
        }

        public void DoGoPlan()
        {
            ShowViewModel<JourneyComPlanViewModel>();
        }

    }
}
