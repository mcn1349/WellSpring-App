using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IMeetupsTableDatabase
    {
        Task<IEnumerable<MeetupsTable>> GetConnection();

        Task<int> InsertMeetUp(MeetupsTable meetup);
        Task<int> InsertMeetUp(MeetupsTableAutoCompleteResult meetup);

        Task<bool> CheckIfExists(MeetupsTable food);
        Task<bool> CheckIfExists(MeetupsTableAutoCompleteResult meetup);
        Task<IEnumerable<MeetupsTable>> GetMeetUp();
    }
}
