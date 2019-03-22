using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IFoodEnteredTableDatabase
    {
        Task<IEnumerable<FoodEnteredTable>> GetConnection();

        Task<int> InsertFood(FoodEnteredTable food);
        Task<int> InsertFood(FoodEnteredTableAutoCompleteResult food);

        Task<bool> CheckIfExists(FoodEnteredTable food);
        Task<bool> CheckIfExists(FoodEnteredTableAutoCompleteResult food);

        Task<IEnumerable<FoodEnteredTable>> GetFood();
        Task<int> DeleteFood(object id);
    }
}