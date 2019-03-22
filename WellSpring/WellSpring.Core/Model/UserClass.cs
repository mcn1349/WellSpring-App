using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class UserClass
    {
        //These two are not that much needed
        public string Email { get; set; }
        public string Password { get; set; }


        public int UserID { get; set; }
        public string Users_Name { get; set; }
        public int AimCalorie { get; set; }
        public int Weight { get; set; }
        public DateTime DOB { get; set; }
        public string Occupation { get; set; }

        private FoodClass Receipe { get; set; }

    }
}
