using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;

namespace WellSpring.Core.ViewModels
{
    public class CommunityNurseViewModel
        : MvxViewModel
    {
        private string _question;
        public string Question
        {
            get { return _question; }
            set
            {
                if (value != null && value != _question)
                {
                    _question = value;
                    RaisePropertyChanged(() => Question);
                }
            }
        }
        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set { SetProperty(ref _detail, value); }
        }



        public ICommand ConcernCommand { get; set; }
        public ICommand AskCommand { get; set; }
        public ICommand SendCommand { get; set; }
        public ICommand Close { get; set; }

        public JourneyDatabaseAzure JourneyDB = new JourneyDatabaseAzure();
        public CommunityNurseViewModel()
        {
            ConcernCommand = new MvxCommand(() =>
            {
                ShowViewModel<ViewModels.CommunityConcernViewModel>();
            });

            SendCommand = new MvxCommand(() =>
            {
                JourneyDB.Something();
            });

        }
    }
}
