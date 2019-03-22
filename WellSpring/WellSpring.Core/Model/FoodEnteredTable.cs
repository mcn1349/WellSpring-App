using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class FoodEnteredTable
    {
        public FoodEnteredTable() { }
        public FoodEnteredTable(FoodEnteredTableAutoCompleteResult food)
        {
            UserID = food.UserID;
            FoodID = food.FoodID;
            Date = food.Date;
        }

        public string Id { get; set; }

        public string UserID { get; set; }
        public string FoodID { get; set; }
        public DateTime Date { get; set; }

    }
}
