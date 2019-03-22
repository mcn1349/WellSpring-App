using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface ICalendarTableDatabase
    {
        Task<IEnumerable<CalendarTable>> GetConnection();

        Task<int> InsertCalendar(CalendarTable calen);
        Task<int> InsertCalendar(CalendarTableAutoCompleteResult calen);

        Task<bool> CheckIfExists(CalendarTable calen);
        Task<bool> CheckIfExists(CalendarTableAutoCompleteResult calen);

        Task<IEnumerable<CalendarTable>> GetCalendar();
        Task<int> DeleteCalendar(object id);
    }
}
