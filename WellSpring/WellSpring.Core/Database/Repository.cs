using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Interfaces;

using SQLite.Net;
using MvvmCross.Platform;
using WellSpring.Core.Model;
using MvvmCross.Binding.BindingContext;

namespace WellSpring.Core.Database
{
    public class Repository : IRepository
    {
        private SQLiteConnection database;

        public Repository()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<TodoItem>();
        }


        public TodoItem GetItem(int id)
        {
            return database.Table<TodoItem>().FirstOrDefault(x => x.ID == id);
        }

        public int SetDate(DateTime Val)
        {
            var num = database.Insert(Val);
            database.Commit();
            return num;
        }

        public void DeleteItem(int id)
        {
            database.Delete<TodoItem>(id);
        }
    }
}
