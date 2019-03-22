using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IUserTableDatabase
    {
        Task<IEnumerable<UserTable>> GetConnection();

        Task<int> InsertUser(UserTable user);
        Task<int> InsertUser(UserTableAutoCompleteResult user);

        Task<bool> CheckIfExists(UserTable user);
        Task<bool> CheckIfExists(UserTableAutoCompleteResult user);
        Task<IEnumerable<UserTable>> GetUser();
    }
}
