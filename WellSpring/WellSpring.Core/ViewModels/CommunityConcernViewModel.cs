using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WellSpring.Core.ViewModels
{
    public class CommunityConcernViewModel
        : MvxViewModel
    {
        public ICommand ConcernClickCommand { get; private set; }
        public CommunityConcernViewModel()
        {
            string[] quest = new string[] {
                "I've been having a headache lately",
                "I've been having a hard time sleeping",
                "I am feeling a bit dizzy",
                "Why do I always feel tired?",
                "I have been coughing a lot lately",
                "Why do I always feel like vomiting?",
                "I've been having a fever lately",
                "I have been coughing a lot lately",
                "I have been losing my hair everyday",
                "I think I am starting to lose my appetite",
                "I think I have been losing weight a lot lately",
                "Why is my sense of smell different?",
                "I feel like my taste buds are becoming different",
                "I feel like my skin is becoming lighter",
                "I am having a hard time concentrating on certain topics lately"};

            List<string> newList = new List<string>();
            for (int i = 0; i < quest.Length; i += 1)
            {
                newList.Add(quest[i]);
            }
            ConcernFrames = newList;

            ConcernClickCommand = new MvxCommand<string>(send =>
            {
                Close(this);
                ShowViewModel<CommunityAfterConsultViewModel>(new { parameter = send });
            });

        }
        private List<string> _concernFrames;

        public List<string> ConcernFrames
        {
            get { return _concernFrames; }
            set { SetProperty(ref _concernFrames, value); }
        }
    }
}
