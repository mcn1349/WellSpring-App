using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WellSpring.Core.ViewModels
{
    public class CommunityConsultViewModel : MvxViewModel
    {
        public ICommand History { get; set; }
        public ICommand Message { get; set; }
        public ICommand Nurse { get; set; }

        
        public CommunityConsultViewModel()
        {
            History = new MvxCommand(() =>
            {
                ShowViewModel<ViewModels.CommunityHistoryConsultViewModel>();
            });

            Message = new MvxCommand(() =>
            {
                ShowViewModel<ViewModels.CommunityMessageViewModel>();
            });

            Nurse = new MvxCommand(() =>
            {
                ShowViewModel<ViewModels.CommunityNurseViewModel>();
            });

        }
    }
}
