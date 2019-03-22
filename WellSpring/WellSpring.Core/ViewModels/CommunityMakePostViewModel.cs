using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class CommunityMakePostViewModel : MvxViewModel
    {
        public ICommand Community { get; set; }

        public CommunityMakePostViewModel()
        {
            Community = new MvxCommand(() =>
            {
                userpost();
                Close(this);//ShowViewModel<ViewModels.CommunityViewModel>(); // this contains code that needs to be fixed
            });
           
        }

        private string _post;
        public string Post
        {
            get { return _post; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _post, value);
                }
            }
        }

        private CommunityPostTableAutoCompleteResult info = new CommunityPostTableAutoCompleteResult();
        private ICommunityPostTableDatabase postDatabase;

        public void userpost()
        {
            postDatabase = new CommunityPostTableDatabaseAzure();
            info.Description = Post;
            postDatabase.InsertCommunityPost(info);
        }
    }
}
