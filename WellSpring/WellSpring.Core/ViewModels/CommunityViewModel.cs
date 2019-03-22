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
    public class CommunityViewModel : MvxViewModel
    {
        public ICommand CreateMeetup { get; set; }
        public ICommand FindMeetup { get; set; }
        public ICommand MakePost { get; set; }
        public ICommand Consult { get; set; }

        private ObservableCollection<CommunityPostTable> cps;
        public ObservableCollection<CommunityPostTable> Cps
        {
            get { return cps; }
            set { SetProperty(ref cps, value); }
        }

        public CommunityViewModel()
        {
            CreateMeetup = new MvxCommand(() =>
            {
                ShowViewModel<ViewModels.CommunityCreateMeetupViewModel>();
            });

            FindMeetup = new MvxCommand(() =>
            {
                ShowViewModel<ViewModels.CommunityFindMeetupViewModel>();
            });

            MakePost = new MvxCommand(() =>
            {
                ShowViewModel<ViewModels.CommunityMakePostViewModel>();
            });

            Consult = new MvxCommand(() =>
            {
                ShowViewModel<ViewModels.CommunityConsultViewModel>();
            }
            );

            cps = new ObservableCollection<CommunityPostTable>();
            startup();
        }

        private ICommunityPostTableDatabase communityPostDatabase;
        private async void startup()
        {
            communityPostDatabase = new CommunityPostTableDatabaseAzure();
            var details = await communityPostDatabase.GetCp();
            foreach (var detail in details)
            {
                cps.Add(detail);
            }
        }
    }
}
