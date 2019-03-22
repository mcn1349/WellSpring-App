using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Interfaces;

namespace WellSpring.Core.ViewModels
{
    public class CommunityMessageViewModel
        : MvxViewModel
    {
        private IDialogService dialog;
        public ICommand DateDialogCommand { get; private set; }
        public ICommand TimeDialogCommand { get; private set; }

        
        private string _date;
        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private string _time;
        public string Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        public CommunityMessageViewModel(IDialogService dialog)
        {
            this.dialog = dialog;
            DateDialogCommand = new MvxCommand(() =>
            {
                DoDateDialog();
            });
            TimeDialogCommand = new MvxCommand(() =>
            {
                DoTimeDialog();
            });

        }

        public async void DoDateDialog()
        {
            
            bool date;
            date = await dialog.alertMessage(Date, "Test");
            //await dialog.alertMessage("title", "message");
        }

        public async void DoTimeDialog()
        {
            bool time;
            time = await dialog.alertMessage(Time, "Test");
        }

    }
}
