using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class ToDoItemAutoCompleteResult
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string LocalizedName { get; set; }
        public DateTime Date { get; set; }
    }
}
