using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IRepository
    {
        TodoItem GetItem(int id);
        int SetDate(DateTime Val);
        void DeleteItem(int id);
    }
}
