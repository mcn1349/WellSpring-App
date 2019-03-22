using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class ExcerciseClass
    {
        public int UserID { get; set; }
        public string Workout { get; set; }
        public int Distance { get; set; }
        public DateTime Duration { get; set; }
        public int Calories { get; set; }
        public int Laps { get; set; }
        public int Sets { get; set; }
    }
}
