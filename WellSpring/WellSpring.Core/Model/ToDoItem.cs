using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class TodoItem
    {
        public TodoItem() { }

        public TodoItem(ToDoItemAutoCompleteResult ToDoItem) { 
            ChosenDate = ToDoItem.Date;
        }

        public int ID { get; set; }
        public string Text { get; set; }

        public DateTime ChosenDate { get; set; }
    }
}
