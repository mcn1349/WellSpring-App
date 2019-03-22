using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WellSpring.Core.ViewModels
{
    public class JourneyComPlanViewModel
        : MvxViewModel
    {
        private string _comPlan;
        public string ComPlan
        {
            get { return _comPlan; }
            set
            {
                if (value != null && value != _comPlan)
                {
                    _comPlan = value;
                    RaisePropertyChanged(() => ComPlan);
                }
            }
        }

        /*--------------------------------------------------------------------------------------------*/

    }
}
