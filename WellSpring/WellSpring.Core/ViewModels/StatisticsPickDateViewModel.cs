using MvvmCross.Core.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class StatisticsPickDateViewModel : MvxViewModel
    {
        private DateTime from;
        public DateTime From
        {
            get { return from; }
            set { SetProperty(ref from, value); }

        }

        private DateTime to;
        public DateTime To
        {
            get { return to; }
            set { SetProperty(ref to, value); }
        }

        public string Title { get; set; }

        public ICommand Confirm { get; private set; }
        //public ObservableCollection<GraphModel> gms { get; set; }
        //public ICalendarTableDatabase CalenDatabase { get; set; }

        
        public void Init(DateModel dm)
        {
            Title = dm.Title;
            from = Convert.ToDateTime(dm.Start);
            to = Convert.ToDateTime(dm.End);
            //CalenDatabase = dm.CalenDatabase;
        }


        public StatisticsPickDateViewModel()
        {
            Confirm = new MvxCommand(() => {
                ShowViewModel<StatisticsDetailViewModel>(new DateModel(Title, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy") ));
                Close(this);
            }
              );
        }

    }
}
