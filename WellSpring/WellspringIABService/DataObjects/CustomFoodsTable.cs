using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class CustomFoodsTable : EntityData
    {
        public string UserID { get; set; }
        public string FoodName { get; set; }
        public string FoodIngredients { get; set; }
        public string FoodMethod { get; set; }
        public int Protein { get; set; }
        public int Calories { get; set; }
        public int Fat { get; set; }
        public int Carbohydrate { get; set; }
        public int Fiber { get; set; }
        public int Cholesterol { get; set; }
        public int Sodium { get; set; }
    }
}