using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class FoodsTableAutoCompleteResult
    {
        [PrimaryKey, AutoIncrement]

        public string Id { get; set; }
        [JsonProperty("FoodName")]
        public string FoodName { get; set; }
        [JsonProperty("FoodIngredients")]
        public string FoodIngredients { get; set; }
        [JsonProperty("FoodMethod")]
        public string FoodMethod { get; set; }
        [JsonProperty("Protein")]
        public int Protein { get; set; }
        [JsonProperty("Calories")]
        public int Calories { get; set; }
        [JsonProperty("Fat")]
        public int Fat { get; set; }
        [JsonProperty("Carbohydrate")]
        public int Carbohydrate { get; set; }
        [JsonProperty("Fiber")]
        public int Fiber { get; set; }
        [JsonProperty("Cholesterol")]
        public int Cholesterol { get; set; }
        [JsonProperty("Sodium")]
        public int Sodium { get; set; }

    }
}
