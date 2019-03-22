using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class FoodList
    {
        public string Food { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public string Calorie { get; set; }
        public string Fat { get; set; }
        public string Carbohydrate { get; set; }
        public string Protein { get; set; }
        public string Fiber { get; set; }
        public string Cholestrol { get; set; }
        public string Sodium { get; set; }
        public FoodList() { }
        public FoodList(string food, string ingredients, string method, string calorie, string fat
            , string carbohydrate, string protein, string fiber, string cholestrol, string sodium)
        {
            Food = food;
            Ingredients = ingredients;
            Method = method;
            Calorie = calorie;
            Fat = fat;
            Carbohydrate = carbohydrate;
            Protein = protein;
            Cholestrol = cholestrol;
            Sodium = sodium;
            Fiber = fiber;
        }
    }
}
