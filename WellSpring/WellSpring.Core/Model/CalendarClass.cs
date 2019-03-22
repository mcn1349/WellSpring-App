using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class CalendarClass
    {
        public int UserID { get; set; }
        public DateTime Date { get; set; }

        private FoodClass[] food_list;
        private ExcerciseClass[] excercise_list;

        public int Work_Calorie { get; set; }

        public int Food_Calorie { get; set; }
        


        public int Combine_Calorie { get { return Work_Calorie + Food_Calorie; } }

        
        public int PlanWeight { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
    }
}
