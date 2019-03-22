using MvvmCross.Core.ViewModels;

namespace WellSpring.Core.ViewModels
{
    public class HomeViewModel 
        : MvxViewModel
    {

        public HomeViewModel()
        {
            Journey = new JourneyViewModel();
            Goal = new GoalViewModel();
            Statistic = new StatisticsViewModel();
            Community = new CommunityViewModel();
        }


        private JourneyViewModel _journey;
        public JourneyViewModel Journey
        {
            get { return _journey; }
            set { SetProperty(ref _journey, value); }
        }
        private GoalViewModel _goal;
        public GoalViewModel Goal
        {
            get { return _goal; }
            set { SetProperty(ref _goal, value); }
        }
        private StatisticsViewModel _statistic;
        public StatisticsViewModel Statistic
        {
            get { return _statistic; }
            set { SetProperty(ref _statistic, value); }
        }

        private CommunityViewModel _community;
        public CommunityViewModel Community
        {
            get { return _community; }
            set { SetProperty(ref _community, value); }
        }
    }
   
}
