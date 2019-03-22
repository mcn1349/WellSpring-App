using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WellSpring.Core.ViewModels
{
    public class SettingViewModel : MvxViewModel
    {
        public ICommand SelectKeyCommand { get; private set; }
        public ICommand TermCommand { get; private set; }
        public SettingViewModel()
        {
            string[] options = new string[]
            {
                "User Account",
                "Goal Setting",
                "Log Out"
            };
            var Option = new List<string>();
            for (int i = 0; i < options.Length; i += 1)
            {
                Option.Add(options[i]);
            }
            ItemList = Option;
            TermList.Add("Terms & Uses");
            SelectKeyCommand = new MvxCommand<string>(selected =>
            {
                if (selected == options[0])
                {
                    //ShowViewModel<>();
                }
                else if (selected == options[1])
                {
                    //ShowViewMOdel<>();
                }
                else
                {
                    //ShowViewModel<>();
                }
            });
            TermCommand = new MvxCommand(() =>
            {
                //ShowViewModel<>();
            });
        }
        private List<string> _ItemList;
        public List<string> ItemList
        {
            get { return _ItemList; }
            set { SetProperty(ref _ItemList, value); }
        }
        private List<string> _termList;
        public List<string> TermList
        {
            get { return _termList; }
            set { SetProperty(ref _termList, value); }
        }
    }
}
