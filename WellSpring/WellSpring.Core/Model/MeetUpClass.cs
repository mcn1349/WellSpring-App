using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class MeetUpClass
    {
        public int MeetID { get; set; }
        private UserClass[] users;
        public UserClass Host { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public string Address_Name { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
    }
}
