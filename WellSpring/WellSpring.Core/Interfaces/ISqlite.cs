using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;

namespace WellSpring.Core.Interfaces
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
