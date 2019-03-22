using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class CommunityFindMeetupViewModel
        : MvxViewModel
    {

        private ObservableCollection<MeetupsTable> meetups;

        public ObservableCollection<MeetupsTable> Meetups
        {
            get { return meetups; }
            set { SetProperty(ref meetups, value); }
        }

        private IMeetupsTableDatabase meetUpTableDatabase;
        public async void Init()
        {
            meetUpTableDatabase = new MeetupsTableDatabaseAzure();
            var details = await meetUpTableDatabase.GetMeetUp();
            foreach (var detail in details)
            {
                Meetups.Add(detail);
            }
        }

        public ICommand GoMeetupCommand { get; set; }
        public CommunityFindMeetupViewModel()
        {
            Meetups = new ObservableCollection<MeetupsTable>();
            GoMeetupCommand = new MvxCommand<MeetupsTable>(meetupDetail =>
            {
                ShowViewModel<CommunityMeetupViewModel>(meetupDetail);
            });
        }
    }
}
