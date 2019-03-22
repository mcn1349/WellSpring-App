using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IGoalTableDatabase
    {
        Task<IEnumerable<GoalTable>> GetConnection();

        Task<int> InsertGoal(GoalTable goal);
        Task<int> InsertGoal(GoalTableAutoCompleteResult goal);

        Task<bool> CheckIfExists(GoalTable goal);
        Task<bool> CheckIfExists(GoalTableAutoCompleteResult goal);
        
    }
}