using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WellSpring.Core.ViewModels
{
    public class JourneyViewModel
        : MvxViewModel
    {
        // Calendar Select
        private MvxCommand _goSelectCommand;
        public ICommand GoSelectCommand
        {
            get
            {
                _goSelectCommand = _goSelectCommand ?? new MvxCommand(DoGoSelect);
                return _goSelectCommand;
            }
        }

        public void DoGoSelect()
        {
            ShowViewModel<JourneyCalendarSelectViewModel>();
        }




        // Community Calendar
        private MvxCommand _goComCalCommand;
        public ICommand GoComCalCommand
        {
            get
            {
                _goComCalCommand = _goComCalCommand ?? new MvxCommand(DoGoComCal);
                return _goComCalCommand;
            }
        }

        public void DoGoComCal()
        {
            ShowViewModel<JourneyComCalendarViewModel>();
        }

        public JourneyViewModel()
        {
        }
    }
}
