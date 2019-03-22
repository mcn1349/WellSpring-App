using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IConsultTableDatabase
    {
        Task<IEnumerable<ConsultTable>> GetConnection();

        Task<int> InsertConsult(ConsultTable consult);
        Task<int> InsertConsult(ConsultTableAutoCompleteResult consult);

        Task<bool> CheckIfExists(ConsultTable consult);
        Task<bool> CheckIfExists(ConsultTableAutoCompleteResult consult);

    }
}
