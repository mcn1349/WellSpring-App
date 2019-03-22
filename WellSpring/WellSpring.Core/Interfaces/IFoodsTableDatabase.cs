using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IFoodsTableDatabase
    {
        Task<IEnumerable<FoodsTable>> GetConnection();

        Task<int> InsertFood(FoodsTable food);
        Task<int> InsertFood(FoodsTableAutoCompleteResult food);

        Task<bool> CheckIfExists(FoodsTable food);
        Task<bool> CheckIfExists(FoodsTableAutoCompleteResult food);

        Task<IEnumerable<FoodsTable>> GetFood();
        Task<int> DeleteFood(object id);
    }
}