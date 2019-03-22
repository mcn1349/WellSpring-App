using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class FoodsTable
    {
        public FoodsTable() { }
        public FoodsTable(FoodsTableAutoCompleteResult food)
        {
            FoodName = food.FoodName;
            FoodIngredients = food.FoodIngredients;
            FoodMethod = food.FoodMethod;
            Protein = food.Protein;
            Calories = food.Calories;
            Fat = food.Fat;
            Carbohydrate = food.Carbohydrate;
            Fiber = food.Fiber;
            Cholesterol = food.Cholesterol;
            Sodium = food.Sodium;
        }

        public string Id { get; set; }
        
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
