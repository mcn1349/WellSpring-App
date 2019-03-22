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
    public class RegisterViewModel
        : MvxViewModel
    {
        UserTableAutoCompleteResult user = new UserTableAutoCompleteResult();
        IUserTableDatabase usersDatabase;

        private MvxCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                _closeCommand = _closeCommand ?? new MvxCommand(InsertingUser);
                return _closeCommand;
            }
        }

        public async void InsertingUser()
        {
            user.Name = "Kazuko";
            user.AimCalorie = 0;
            user.DOB = new DateTime(2000, 1, 1);
            user.Email = "kazuko@wellspring.com";
            user.Weight = 45;
            usersDatabase = new UserTableDatabaseAzure();
            bool _checked = await usersDatabase.CheckIfExists(user);
            if (!_checked)
            {
                await usersDatabase.InsertUser(user);
            }
            Close(this);
        }
    }
}
